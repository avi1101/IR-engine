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

        public Model(string path,bool Tostem)
        {

            ReadFile readfo = new ReadFile(path);
            int filesNum = readfo.returnSize();
            bool hasIndex = File.Exists(path + "\\index_elad_avi");
            if (hasIndex == true)
            {
                /**
                 * add a pop up window to ask whether to re-index the docs in the folder
                **/
            }
            else
            {
                File.CreateText(path + "\\index_elad_avi");
                Parse parser = new Parse(path, Tostem);
            }
            for (int i = 0; i < readfo.returnSize(); i++)
            {
                List<document> f = readfo.getDocs();
            }
        }
    }

}
    

