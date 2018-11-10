using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class Model
    {

        public Model()
        {

            long st = DateTime.Now.Second;
            ReadFile readfo = new ReadFile("C:\\Users\\zeavi\\Desktop\\TEST1");
            int filesNum = readfo.returnSize();
            Parse parser = new Parse("C:\\Users\\zeavi\\Desktop\\TEST1",false);
            List<document> f = readfo.getDocs();
            long nd = DateTime.Now.Second;

            Console.WriteLine(nd - st); }
        }

        public static class Vars
        {
            public static HashSet<string> completeTerms = new HashSet<string>();
        }

    }
    

