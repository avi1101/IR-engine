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
        public Dictionary<string, string> CreateIndex(string path)
        {
            
            return null;
        }

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
        }

        private void sort(int offset, string[] files, string pathToPosting)
        {
            for (int i = offset; i < files.Length; i += (offset+1))
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

        private void merge(int fileCount, string[] files)
        {
            bool MoreToRead = false;
            string[] firstLines = new string[fileCount];
            StreamReader[] sr = new StreamReader[fileCount];
            for(int i = 0; i < fileCount; i++)
            {
                sr[i] = new StreamReader(path + "\\index"+i+"sorted.txt");
            }
            for (int i = 0; i < fileCount; i++)
            {
                firstLines[i] = sr[i].ReadLine();
                if (firstLines[i] != null)
                    MoreToRead = true;
            }
            int lastIndex = 0;
            while (lastIndex < firstLines.Length)
            {
                MoreToRead = false;
                string min = "";
                if(firstLines[lastIndex] == null)
                {
                    int i = lastIndex;
                    for (; i < firstLines.Length && firstLines[i] != null; i++);
                    lastIndex = i;
                }
                min = GetPhrase(firstLines[lastIndex]);
                string phrase;
                for (int i = lastIndex; i < fileCount; i++)
                {
                    if (firstLines[i] == null) continue;
                    phrase = GetPhrase(firstLines[i]);
                    if (string.Compare(min, phrase, true) > 0)
                        min = phrase;
                }
            }
        }

        private string GetPhrase(string line)
        {
            return line.Split('\t')[0];
        }
    }
}
