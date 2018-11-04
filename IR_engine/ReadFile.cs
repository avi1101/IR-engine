using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IR_engine;

namespace IR_engine
{
    class ReadFile
    {
        public static List<document> documents = new List<document>();

        public static void getDocs(string path)
        {
            string[] allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (string fpath in allfiles)
            {
                string f = File.ReadAllText(fpath);
                addtolist(f);
            }
        }

        private static void addtolist(string file)
        {
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
                //documents.Add(d);
            }
        }

        public static void main()
        {
            getDocs("C:\\Users\\zeavi\\Desktop\\TEST1");
            Console.WriteLine("C:\\Users\\zeavi\\Desktop\\TEST1");
        }
    }

}
