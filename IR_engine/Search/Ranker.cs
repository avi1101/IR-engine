using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class Ranker
    {
        public double k1 = 1.2;
        public double k3 = 8;
        public double b = 0.75;
        public double delta = 1.0;   //TODO: change and check

        public List<string> qry = null;
        public List<string> docs = null;


        public Ranker()
        {
        }
        /// <summary>
        /// Uses BM25 to compute a weight for a term in a document.
        /// </summary>
        /// <param name="tf">The term frequency in the document</param>
        /// <param name="numberOfDocuments">number of documents in corpus</param>
        /// <param name="docLength">the document's length</param>
        /// <param name="averageDocumentLength">average document length</param>
        /// <param name="queryFrequency"></param>
        /// <param name="idf"></param>
        /// <returns></returns>
        public double BM25A(double tf, double numberOfDocuments, double docLength, double averageDocumentLength, double queryFrequency, double idf)
        {

            double K = k1 * ((1 - b) + ((b * docLength) / averageDocumentLength));
            double weight = (((k1 + 1d) * tf) / (K + tf));	//first part
            weight = weight * (((k3 + 1) * queryFrequency) / (k3 + queryFrequency));  //second part
            // multiply the weight with idf 
            double idf = weight * Math.Log((numberOfDocuments - documentFrequency + 0.5) / (documentFrequency + 0.5));
            return idf;
        }
        /// <summary>
        /// Returns a relevance score between a term and a document based on a corpus.
        /// </summary>
        /// <param name="tf">the frequency of searching term in the document to rank</param>
        /// <param name="docLength"> the size of document to rank</param>
        /// <param name="averageDocumentLength">the average size of documents in the corpus</param>
        /// <param name="numberOfDocuments">number of documents in the corpus</param>
        /// <param name="idf">number of documents containing the given term in the corpus</param>
        /// <returns></returns>
        /// 
        /*
        public double BM25B(double tf, int docLength, double averageDocumentLength, long numberOfDocuments, long idf)
        {
            private static Dictionary<string, KeyValuePair<int, term.Type>> currentKeywords = new Dictionary<string, KeyValuePair<int, term.Type>>();
        List<KeyValuePair<string, string>> qry;
            Dictionary<string, List<string>> fin = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, string> q in qry.value    )
            {
                if (!fin.ContainsKey(q.Key))
                {
                    List<string> x = new List<string>();
                    x.Add(q.Value);
                    fin.Add(q.Key, x);
                }
                else { fin[q.Key].Add(q.Value); }
            }
            foreach (string value in fin.Keys)
            {
                using (StreamReader sr)
            }



            if (tf <= 0) return 0.0;
            double tf2 = tf * (k1 + 1) / (tf + k1 * (1 - b + b * docLength / averageDocumentLength));
            double idf = Math.Log((numberOfDocuments - documentFrequency + 0.5) / (documentFrequency + 0.5));

            return (tf2+delta) * idf;
        }
        */

        // changed: Elad
        //
        // Dictionary<string, KeyValuePair<int, term.Type>>> = <the term from the query, <occurances in the query, term type>>
        // the dictionary contains all terms from the query
        //
        // List<string> = a list of all retrieved documents you'll need to rank
        //
        public double BM25B(Dictionary<string, KeyValuePair<int, term.Type>> qries, List<string> docs)
        {
            Dictionary<string, List<string>> fin = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<int, term.Type> q in qries.Values)
            {
                if (!fin.ContainsKey(q.Value + ""))
                {
                    List<string> x = new List<string>();
                    x.Add(qries)
                    fin.Add(q.Key, x);
                }
                else { fin[q.Key].Add(q.Value); }
            }
        }
    }
}
