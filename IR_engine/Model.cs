using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NSoup;
using NSoup.Nodes;

namespace IR_engine
{
    class Model
    {
        Parse parser;
        ReadFile readfo;
        string path;
        bool ToStem;

        public Model(string path,bool Tostem)
        {

            readfo = new ReadFile(path);
            this.path = path;
            this.ToStem = Tostem;
            parser = new Parse(path, ToStem);
        }

        public void index()
        {
            // step one, the parsing
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int filesNum = readfo.returnSize();
            bool hasIndex = File.Exists(path + "\\index_elad_avi.txt");
            if (hasIndex == true)
            {
                /**
                 * add a pop up window to ask whether to re-index the docs in the folder
                **/
            }
            else
            {
                File.CreateText(path + "\\index_elad_avi.txt");
            }
            for (int i = 0; i < readfo.returnSize(); i++)
            {
                List<document> f = readfo.getDocs();
                if (f == null) continue;
                for(int j = 0; j < f.Count; j++)
                {
                    //parser.Text2list(f[j]);
                }
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time: " + elapsedMs);
            Console.WriteLine("Time in getDoc: " + readfo.time);
        }

        public Dictionary<string, term> getDictionary()
        {
            return Parse.terms;
        }
    }

}
    

