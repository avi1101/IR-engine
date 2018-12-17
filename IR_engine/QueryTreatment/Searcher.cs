using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine.QueryTreatment
{
    class Searcher
    {
        string[] returnedDocs = new string[50]; //amount of returned documents is restricted to 50
        string[] entities = new string[5]; //amount of entities is restricted to 5
        List<string> docsIncities = new List<string>(); //the docs we want to search in
        public Searcher()
        {

        }


        //public void joinQ(string path)
        //{
          //  string file = File.ReadAllText(path + @"\queries.txt");
            //string[] qries = file.Split(new string[] { "<top>" }, StringSplitOptions.RemoveEmptyEntries);
            /*foreach (string qry in qries)
            {
                int st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, end1 = 0, end2 = 0, end3 = 0, end4 = 0, end5 = 0, st6 = 0, end6 = 0;
                if (qry.Equals("")) continue;
                string QNum = "";
                string date = "";
                string head = "";
                string data = "";
                if (qry != "\n")
                {
                    st1 = qry.IndexOf("<num>");
                    if (st1 != -1)
                        end1 = qry.IndexOf("</DOCNO>", st1);
                    if (st1 != -1 && end1 != -1) {  QNum = doc.Substring(st1 + 7, (end1 - st1) - 7); }

                }*/
        public void search(string query, List<string> cities, string dataPath)
        {
            string[] qry = query.Split(' ');
            string line;
            HashSet<string> ctHash = new HashSet<string>();
            foreach (string city in cities)
            {
                ctHash.Add(city);
            }
            if (cities != null && cities.Count > 0)
            {
                using (StreamReader st = new StreamReader(dataPath + "\\documents.txt"))
                {
                    while ((line = st.ReadLine()) != null)
                        if (ctHash.Contains(line.Split('\t')[4]))
                            docsIncities.Add(line.Split('\t')[0]);
                }

            }
            else
            {
                using (StreamReader st = new StreamReader(dataPath + "\\documents.txt"))
                {
                    while ((line = st.ReadLine()) != null)
                        docsIncities.Add(line.Split('\t')[0]);
                }
            }
            //TODO: send list of docs to rank
        }
    }
}
