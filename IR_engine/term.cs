using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
     class term
    {
        string phrase;
        int numOfDocs;
        int globalOccurances;
        bool isUpperInCurpus;
        Dictionary<string, int> numInDoc;  
        Dictionary<string, Tuple<string, int>> forPosting;
        List<string> postingList; //this will be used in the format: <filename>_<number of occurances of the term>

        public term()
        {
            IsUpperInCurpus = true;
            postingList = new List<string>();
            numOfDocs = globalOccurances = 0;
            phrase = "";
        }

        public term(string phrase)
        {
            Phrase = phrase;
            IsUpperInCurpus = true;
            postingList = new List<string>();
            numOfDocs = globalOccurances = 0;
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

        public int GlobalOccurances { get => globalOccurances; set => globalOccurances = value; }
        public bool IsUpperInCurpus { get => isUpperInCurpus; set => isUpperInCurpus = value; }

        /// <summary>
        /// this method check equality between this object and a given object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var term = obj as term;
            return term != null &&
                   phrase == term.Phrase;
        }

        public override int GetHashCode()
        {
            return 2090604936 + EqualityComparer<string>.Default.GetHashCode(phrase);
        }

        public void shown()
        {
            numOfDocs++;
        }

        public void addDocumentToPostingList(string filename, int occurances)
        {
            postingList.Add(filename + "_" + occurances);
        }
    }
}
