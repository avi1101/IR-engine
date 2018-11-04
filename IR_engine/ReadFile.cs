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
    class ReadFile
    {
        string[] allfiles = null;
        int index = 0;
        ReadFile(string path)
        {
            allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        }
        /// <summary>
        /// this function gets all docs in the corpus folder and its sub-folders.
        /// </summary>
        /// <param name="path"></param>
        public List<document> getDocs()
        {
            return readfile(File.ReadAllText(allfiles[index++]));
             
        }
        /// <summary>
        /// this function create an document type objects from the string file, and sends it to the parser
        /// 
        /// </summary>
        /// <param name="file"> the string that constains all the data in the file</param>
        private static List<document> readfile(string file)
        {
            
            List<document> docslist = new List<document>();
            string[] docs = file.Split(new string[] { "<DOC>" }, StringSplitOptions.None);
            foreach (string doc in docs)
                if (doc != "" && doc!="\n") { 
                int st = doc.IndexOf("<DOCNO>");
                int end = doc.IndexOf("</DOCNO");
                string docNo = doc.Substring(st+7, (end - st)-8).Trim();
                st = doc.IndexOf("<DATE1>");
                end = doc.IndexOf("</DATE1>");
                string date = doc.Substring(st+7, (end - st) - 8).Trim();
                st = doc.IndexOf("<TI>");
                end = doc.IndexOf("</TI>");
                string head = doc.Substring(st+4, (end - st) - 4).Trim();
                st = doc.IndexOf("<TEXT>");
                end = doc.IndexOf("</TEXT>");
                string data = doc.Substring(st+6, (end - st) - 7).Trim();
                document d = new document(data, docNo, date, head);
                docslist.Add(d);
            }
            return docslist;
        }
    }
}
