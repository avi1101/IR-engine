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
        public List<string> allfiles = null;

        public static long timepertDoc = 0;
        public static long readFiles_time = 0;
        int index = 0;
        int allfilesSize = 0;
        string path;
        static int counter = 0;
        Parse parser;

        public ReadFile(string path)
        {

            this.path = path;
            string[] tmp = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            allfiles = tmp.ToList();
            allfiles.Remove(path + "\\stop_words.txt");
            allfiles.Remove(path + "\\postingList.txt");
            //TODO: remove also posting list files and index file
            allfilesSize = allfiles.Count;
            parser = new Parse(path, false);
        }
        /// <summary>
        /// this function gets all docs in the corpus folder and its sub-folders.
        /// </summary>
        /// <param name="path"></param>
        public List<document> getDocs()
        {
           
            if (index + 1< allfilesSize)
            {
                index++;
                string[] ext = allfiles[index].Split('.');
                if (ext[ext.Length - 1].Equals("txt")) return null;
                //List < document > ans = readfile(File.ReadAllText(allfiles[index++]));
                
                //return ans;
            }
            return null;
        }
        /// <summary>
        /// this function create an document type objects from the string file, and sends it to the parser
        /// 
        /// </summary>
        /// <param name="file"> the string that constains all the data in the file</param>
        public List<document> readfile(string file2, int queue)
        {
            
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            List<document> docslist = new List<document>();
            string file = File.ReadAllText(file2);
            //file = File.ReadAllText(file);
            string[] docs = file.Split(new string[] { "<DOC>" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string doc in docs)
            {
                StringBuilder sb = new StringBuilder(doc);
                int st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, end1 = 0, end2 = 0, end3 = 0, end4 = 0, end5 = 0;
                if (doc.Equals("")) continue;
                string docNo = "";
                string date = "";
                string head = "";
                string data = "";
                if (doc != "\n")
                {
                    st1 = doc.IndexOf("<DOCNO>");
                    if (st1 != -1)
                        end1 = doc.IndexOf("</DOCNO>", st1);
                    if (st1 != -1 && end1 != -1) { docNo = /*RemoveStringReader*/(/*doc.Substring(st1 + 7, (end1 - st1) - 8));*/sb.ToString(st1 + 7, (end1 - st1) - 8)); }
                    st2 = doc.IndexOf("<DATE1>");
                    if (st2 != -1)
                        end2 = doc.IndexOf("</DATE1>", st2, 50);
                    if (st2 != -1 && end2 != -1) { date =/* RemoveStringReader*/(/*doc.Substring(st2 + 7, (end2 - st2) - 8));*/sb.ToString(st2 + 7, (end2 - st2) - 8)); }
                    st3 = doc.IndexOf("<TI>");
                    if (st3 != -1) end3 = doc.IndexOf("</TI>", st3, 100);
                    if (st3 != -1 && end3 != -1) { head =/* RemoveStringReader*/(/*doc.Substring(st3 + 4, (end3 - st3) - 4));*/sb.ToString(st3 + 4, (end3 - st3) - 4)); }
                    st4 = doc.IndexOf("<TEXT>");
                    if (st4 != -1) end4 = doc.IndexOf("</TEXT>", st4);
                    if (st4 != -1 && end4 != -1) { data = /*RemoveStringReader*/(/*doc.Substring(st4 + 6, (end4 - st4) - 7));*/sb.ToString(st4 + 6, (end4 - st4) - 7)); }
                    st5 = doc.IndexOf("<F P=104>");
                    if (st5 != -1)
                    {
                        end5 = doc.IndexOf("</F>", st5, 100);
                    }
                    string city = "";
                    if (st5 != -1 && end5 != -1) { city = ( /*doc.Substring(st5 + 9, (end5 - st5) - 4).Trim();*/sb.ToString(st5 + 9, (end5 - st5) - 9)); }
                    document d = new document(data, docNo, date, head, city);
                    docslist.Add(d);
                    counter++;
                    parser.Text2list(d, queue);
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
    }
}
