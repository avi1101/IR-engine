using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
     class term
    {
        static string phrase;
        static int numOfDocs;
        static Dictionary<string, int> numInDoc;  
        static Dictionary<string, Tuple<string, int>> forPosting;

        static term()
        {
            phrase = "";
        }

        public string Phrase
        {
            set { phrase = value; }
            get { return phrase; }
        }
        public int NumofDocs
        {
            set { numOfDocs = value; }
            get { return numOfDocs;}
        }

        public static void shown()
        {
            numOfDocs++;
        }
    }
}
