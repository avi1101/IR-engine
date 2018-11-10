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

            }
        }
    }

}
    

