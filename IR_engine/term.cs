using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class term
    {
        string frase;
        int numOfDocs;
        Dictionary<string, int> numInDoc;

        public term()
        {
            frase = null;
            numOfDocs = 0;
            numInDoc = new Dictionary<string, int>();
        }
        public void addDoc(string docID)
        {
            numInDoc[docID] = 1;
        }
        public void shown()
        {
            numOfDocs++;
        }
    }
}
