using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IR_engine
{
    class Indexer
    {
        string ipath;
        string path;
        Dictionary<string, Tuple<short, int>> index;    //term-<file,line in file>

        public Indexer(string ipath, string path)
        {
            this.ipath = ipath;             //path to the desired directory where the index will be stored
            this.path = path;               //path to the unsorted posting files (as Parser outputted)
            this.index = new Dictionary<string, Tuple<short, int>>();
        }

        /// <summary>
        /// this method creates an index file in the given directory and returns 
        /// a dictionary of terms and file pointer
        /// </summary>
        /// <param name="path"> the path to the unproccessed index files the Parser creates</param>
        /// <returns> a dictionary of terms </returns>
        public Dictionary<string, List<string>> CreateIndex()
        {
            SortPostings();
            Dictionary<string, List<string>> index = new Dictionary<string, List<string>>();
            List<string> termsList = new List<string>();
            termsList = File.ReadAllText(ipath + "\\index.txt").Split('\n').ToList();
            for(int i = 0; i < termsList.Count; i++)
            {
                string[] entry = termsList[i].Split('\t');
                if(index.ContainsKey(entry[0]))
                {
                    index[entry[0]].Add(entry[1]);
                }
                else
                {
                    index.Add(entry[0], new List<string>());
                    index[entry[0]].Add(entry[1]);
                }
            }
            return index;
        }

        /// <summary>
        /// this method initiates the indexing process, manages the sorting algorithm and tasks
        /// and the merge
        /// </summary>
        private void SortPostings()
        {
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            List<Task> t = new List<Task>();
            for(int i = 0; i < Model.cores; i++)
            {
                int k = i;
                t.Add(Task.Factory.StartNew(() => sort(k, files, path)));
            }
            foreach (Task tsk in t)
                tsk.Wait();
            for (int i = 0; i < files.Length; i++)
                File.Delete(files[i]);
            if (!Directory.Exists(ipath))
                Directory.CreateDirectory(ipath);
            merge(files.Length, files);
        }

        /// <summary>
        /// this method sorts the temporal files by an ascending lexicographic order of the phrases
        /// </summary>
        /// <param name="offset">the serial number of the task</param>
        /// <param name="files">the files array</param>
        /// <param name="pathToPosting">the path to the temportal files</param>
        private void sort(int offset, string[] files, string pathToPosting)
        {
            for (int i = offset; i < files.Length; i += (Model.cores))
            {
                List<string> fileContent = File.ReadAllText(files[i]).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                fileContent = fileContent.OrderBy(s => s.Split(new string[] { "\t" }, StringSplitOptions.None)[0]).ToList();
                using (StreamWriter sr = new StreamWriter(pathToPosting + "\\index" + i + "sorted.txt"))
                {
                    foreach (string s in fileContent)
                        sr.WriteLine(s);
                }
                Console.WriteLine(i + " files sorted");
            }
        }

        /// <summary>
        /// this method efficiently merge the newly created sorted files into posting files and
        /// creates the index in the desired index path
        /// </summary>
        /// <param name="fileCount">number of files</param>
        /// <param name="files">files array</param>
        private void merge(int fileCount, string[] files)
        {
            bool MoreToRead = false;
            string[] firstLines = new string[fileCount];
            string[] sortedFirstLines;
            StreamReader[] sr = new StreamReader[fileCount];
            Dictionary<string, StreamWriter> writers = new Dictionary<string, StreamWriter>();
            for (int i = 0; i < fileCount; i++)
            {
                sr[i] = new StreamReader(path + "\\index" + i + "sorted.txt");
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                writers.Add(c + "", new StreamWriter(ipath + "\\" + c + ".txt"));
            }
            foreach (term.Type t in Enum.GetValues(typeof(term.Type)))
            {
                if (t == term.Type.word) continue;
                writers.Add(t.ToString(), new StreamWriter(ipath + "\\" + t.ToString() + ".txt"));
            }
            writers.Add("other", new StreamWriter(ipath + "\\other.txt"));
            writers.Add("index", new StreamWriter(ipath + "\\index.txt"));
            for (int i = 0; i < fileCount; i++)
            {
                firstLines[i] = sr[i].ReadLine();
                if (firstLines[i] == null)
                    firstLines[i] = "\0";
                if (firstLines[i] == "")
                    i--;
                if (firstLines[i] != null)
                    MoreToRead = true;
            }
            int lastIndex = 0;
            StringBuilder minLine = new StringBuilder();
            StringBuilder minPhrase = new StringBuilder();
            while (lastIndex < firstLines.Length)
            {
                minPhrase.Clear();
                minLine.Clear();
                int i = lastIndex;
                sortedFirstLines = firstLines.OrderBy(s => s.Split(new string[] { "\t" }, StringSplitOptions.None)[0]).ToArray();
                for (i = 0; i < sortedFirstLines.Length; i++)
                {
                    if (sortedFirstLines[i].Equals("\0")) continue;
                    else break;
                }
                if (i >= sortedFirstLines.Length) break;
                minPhrase.Append(GetPhrase(sortedFirstLines[i]));
                bool Cap = true;
                term.Type type = GetType(sortedFirstLines[i]);
                double icf = 0;
                double idf = 0;
                for (i = 0; i < sortedFirstLines.Length; i++)
                {
                    if (string.Compare(minPhrase.ToString(), GetPhrase(sortedFirstLines[i]), true) == 0)
                    {
                        if (type != GetType(sortedFirstLines[i])) continue;
                        string[] splitted = sortedFirstLines[i].Split('\t');
                        Cap &= splitted[1].Equals("True") ? true : false;
                        minLine.Append(splitted[5]);
                        icf += double.Parse(splitted[3]);
                        idf += double.Parse(splitted[4]);
                    }
                    else break;
                }
                minLine.Append("\t");
                minLine.Append(icf);
                minLine.Append("\t");
                minLine.Append(idf);
                string termPhrase = "";
                if (Cap) termPhrase = minPhrase.ToString().ToUpper();
                else termPhrase = minPhrase.ToString().ToLower();
                if (type == term.Type.word)
                {
                    if (char.IsLetter(minPhrase[0]))
                    {
                        writers[Char.ToUpper(minPhrase[0]).ToString()].WriteLine(termPhrase + "\t" + minLine.ToString());
                    }
                    else
                    {
                        writers["other"].WriteLine(termPhrase + "\t" + minLine.ToString());
                    }
                }
                else
                {
                    writers[type.ToString()].WriteLine(termPhrase + "\t" + minLine.ToString());
                }
                for (i = 0; i < fileCount; i++)
                {
                    if (string.Compare(minPhrase.ToString(), GetPhrase(firstLines[i]), true) == 0)
                    {
                        if (type != GetType(firstLines[i])) continue;
                        if (firstLines[i].Equals("\0")) continue;
                        firstLines[i] = sr[i].ReadLine();
                        if (firstLines[i] == null)
                            firstLines[i] = "\0";
                        while (firstLines[i] == "")
                        {
                            firstLines[i] = sr[i].ReadLine();
                            if (firstLines[i] == null)
                                firstLines[i] = "\0";
                        }
                    }
                }
                writers["index"].WriteLine(termPhrase + "\t" + type);
            }
            for (int i = 0; i < fileCount; i++)
            {
                sr[i].Close();
                File.Delete(path + "\\index" + i + "sorted.txt");
            }
            foreach (KeyValuePair<string, StreamWriter> entry in writers)
            {
                entry.Value.Close();
            }
        }

        private string GetPhrase(string line)
        {
            return line.Split('\t')[0];
        }

        private term.Type GetType(string line)
        {
            string type = line.Split('\t')[2];
            term.Type e = (term.Type)Enum.Parse(typeof(term.Type), type, true);
            return e;
        }
    }
}
