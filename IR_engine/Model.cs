using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IR_engine
{
    class Model
    {
        Parse parser;
        ReadFile readfo;

        string path;
        bool ToStem;
       // public static long time_getDoc = 0;
      //  double st;
        public Model(string path,bool Tostem)
        {
            
            //  st = DateTime.Now.Second;
            readfo = new ReadFile(path);
            this.path = path;
            this.ToStem = Tostem;
            parser = new Parse(path, ToStem);
        }

        public void index()
        {
            // step one, the parsing
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
            //    var watch = System.Diagnostics.Stopwatch.StartNew();
                List<document> f = readfo.getDocs();
             //   watch.Stop();
             //   time_getDoc = time_getDoc + watch.ElapsedMilliseconds;
                if (f == null) continue;
                foreach(document d in f)
                {

                 parser.Text2list(d);
                }
                //System.Diagnostics.Debug.WriteLine("Done with: " + i + " of Files");
            }

        }

        public Dictionary<string, term> getDictionary()
        {
            return Parse.terms;
        }
    }

}
    

