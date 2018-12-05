using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace IR_engine
{
     public class term
     {
        public enum Type { number, date, expression, Quotation, distance, percentage, price, word, range,time };

        string phrase; // the phrase itself
        int idf = 0; // the number of docs this term is in
        public int icf = 0;
        Type type;

        //used for global information, global occurances of the term in the curpus and if upper
        bool isUpperInCurpus;
        //end global variables

        public ConcurrentDictionary<string, short> posting; //string = doc name, int = occurances


        public term()
        {
            IsUpperInCurpus = true;
            phrase = "";
            posting = new ConcurrentDictionary<string, short>();
            idf = icf = 0;
        }

        public term(string phrase)
        {
            Phrase = phrase;
            IsUpperInCurpus = true;
            idf = icf = 0;
            posting = new ConcurrentDictionary<string, short>();
        }

        public string Phrase
        {
            set { phrase = value; }
            get { return phrase; }
        }
        public int Icf
        {
            set { Icf = value; }
            get { return Icf; }
        }

        public bool IsUpperInCurpus { get => isUpperInCurpus; set => isUpperInCurpus = value; }
        public Type Type1 { get => type; set => type = value; }

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

        public void AddToPosting(string doc, short tf)
        {
            this.icf += tf;
            posting.AddOrUpdate(doc, tf, (key, value) => {
                value += tf;
                return value;
            });
        }

        public override string ToString()
        {
            return Phrase + '\t' + isUpperInCurpus + '\t' + type + '\t' + printPosting();
        }

        public void AddToPosting(ConcurrentDictionary<string, short> dictionary)
        {
            foreach(KeyValuePair<string, short> entry in dictionary)
            {
                AddToPosting(entry.Key, entry.Value);
            }
            dictionary.Clear();
        }

        public string printPosting()
        {
            StringBuilder res = new StringBuilder();
            foreach(KeyValuePair<string, short> entry in posting)
            {
                res.Append(entry.Key + "_" + entry.Value + ",");
            }
            return res.ToString();
        }

        public short getTFinDoc(string docname)
        {
            return posting[docname];
        }

        public override int GetHashCode()
        {
            var hashCode = -842790187;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(phrase);
            hashCode = hashCode * -1521134295 + type.GetHashCode();
            return hashCode;
        }
    }
}
