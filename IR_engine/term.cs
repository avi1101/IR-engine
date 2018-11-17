using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
     public class term
    {
        public static int postingFileLine = 0; //global variable to assign pointers

        int pointer;   // pointer to the line in the posting list file
        string phrase; // the phrase itself
        int numOfDocs; // the number of docs this term is in

        //used for global information, global occurances of the term in the curpus and if upper
        int globalOccurances;
        bool isUpperInCurpus;
        //end global variables

        //used to count occurances in the currect file being parsed
        string currectDoc;
        int currectCount;
        //end currect variables

        Dictionary<string, int> numInDoc;  
        Dictionary<string, Tuple<string, int>> forPosting;

        List<string> postingList; //this will be used in the format: <docname>_<number> of occurances of the term>

        public term()
        {
            IsUpperInCurpus = true;
            postingList = new List<string>();
            numOfDocs = globalOccurances = 0;
            phrase = "";
            currectDoc = "";
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
        public int Pointer { get => pointer; set => pointer = value; }

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

        public void addDocumentToPostingList()
        {
            if (currectDoc.Equals("")) return;
            postingList.Add(currectDoc + "_" + currectCount);
            currectDoc = "";
        }

        private void StartNewDocumentCount(string docname)
        {
            currectDoc = docname;
            currectCount = 0;
        }

        public void AddToCount(string docname)
        {
            if(!currectDoc.Equals(docname))
            {
                if(!currectDoc.Equals(""))
                    addDocumentToPostingList();
                StartNewDocumentCount(docname);
            }
            currectCount++;
        }
    }
}
