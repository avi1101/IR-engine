using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IR_engine;

namespace IR_engine
{
    /// <summary>
    /// this is the ReadFile class, this class is incharge of reading the documents
    /// from the given corpus path and sends it to the Parser class
    /// </summary>
    public class ReadFile
    {
        List<string> allfiles = null;
        int index = 0;
        int allfilesSize = 0;
        string path;
        static int counter = 0;
        public ReadFile(string path)
        {
            this.path = path;
            string[] tmp = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            allfiles = tmp.ToList();
            allfiles.Remove(path + "\\stop_words.txt");
            allfiles.Remove(path + "\\postingList.txt");
            allfiles.Remove(path + "\\index_elad_avi.txt");
            //TODO: remove also posting list files and index file
            allfilesSize = allfiles.Count;
        }
        /// <summary>
        /// this function gets all docs in the corpus folder and its sub-folders.
        /// </summary>
        /// <param name="path"></param>
        public List<document> getDocs()
        {
            if (index < allfilesSize)
            {
                string[] ext = allfiles[index].Split('.');
                if (ext[ext.Length - 1].Equals("txt")) return null;
                StringBuilder str = new StringBuilder();
                using (StreamReader sr = File.OpenText(allfiles[index++]))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        str.Append(s + " ");
                    }
                }
                return readfile(str.ToString());
            }
            return null;
        }
        /// <summary>
        /// this function create an document type objects from the string file, and sends it to the parser
        /// 
        /// </summary>
        /// <param name="file"> the string that constains all the data in the file</param>
        public static List<document> readfile(string file)
        {
            List<document> docslist = new List<document>();
            string[] docs = file.Split(new string[] { "<DOC>" }, StringSplitOptions.None);
            foreach (string doc in docs)
            {
                if (doc.Equals("")) continue;
                string docNo = "";
                string date = "";
                string head = "";
                string data = " ";
                if (doc != "" && doc != "\n")
                {
                    int st = doc.IndexOf("<DOCNO>");
                    int end = doc.IndexOf("</DOCNO");
                    if (st != -1 || end != -1) { docNo = RemoveStringReader(doc.Substring(st + 7, (end - st) - 8)); }
                    st = doc.IndexOf("<DATE1>");
                    end = doc.IndexOf("</DATE1>");
                    if (st != -1 || end != -1) { date = RemoveStringReader(doc.Substring(st + 7, (end - st) - 8)); }
                    st = doc.IndexOf("<TI>");
                    end = doc.IndexOf("</TI>");
                    if (st != -1 || end != -1) { head = RemoveStringReader(doc.Substring(st + 4, (end - st) - 4)); }
                    st = doc.IndexOf("<TEXT>");
                    end = doc.IndexOf("</TEXT>");
                    if (st != -1 || end != -1) { data = RemoveStringReader(doc.Substring(st + 6, (end - st) - 7)); }
                    st = doc.IndexOf("<F P=104>");
                    if (st != -1)
                    {
                        end = doc.IndexOf("</F>", st);
                    }
                    string city = "";
                    if (st != -1) { city = doc.Substring(st + 9, (end - st) - 4).Trim(); }
                    document d = new document(data, docNo, date, head, city);
                    docslist.Add(d);
                    counter++;
                }
                 
            }
            return docslist;
        }
        public int returnSize()
        {
            return allfilesSize;
        }
        public static string RemoveStringReader(string input)
        {
            var s = new StringBuilder(input.Length); // (input.Length);
            using (var reader = new StringReader(input))
            {
                int i = 0;
                char c;
                for (; i < input.Length; i++)
                {
                    c = (char)reader.Read();
                    if (!char.IsWhiteSpace(c))
                    {
                        s.Append(c);
                    }
                }
            }

            return s.ToString();
        }
        public void WriteToDisk()
        {

        }
    }
}
