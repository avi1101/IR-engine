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
        static int counter = 0;
        public ReadFile(string path)
        {
            string[] tmp = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            allfiles = tmp.ToList();
            allfiles.Remove(path + "\\stop_words.txt");
            allfilesSize = tmp.Length-1;
        }
        /// <summary>
        /// this function gets all docs in the corpus folder and its sub-folders.
        /// </summary>
        /// <param name="path"></param>
         public List<document> getDocs()
        {
            if (index < allfilesSize)
                return readfile(File.ReadAllText(allfiles[index++]));
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
                if (doc != "" && doc!="\n"){
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
               st = doc.IndexOf("<F P=104>");
                    if (st != -1) { 
                end = doc.IndexOf("</F>",st);
                    }
                    string city = "";
                if (st != -1){ city = doc.Substring(st + 9, (end - st) - 4).Trim(); }
                document d = new document(data, docNo, date, head,city);
                docslist.Add(d);
                    counter++;
                }
            return docslist;
        }
        public int returnSize()
        {
            return allfilesSize;
        }
    }
}
