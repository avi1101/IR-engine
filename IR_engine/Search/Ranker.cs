﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IR_engine
{
    class Ranker
    {
        public double k1 = 1.2;
        public double k3 = 8;
        public double b = 0.75;
        public double delta = 1.0;   //TODO: change and check
        public string dataPath = null;
        public string postPath = null;
        public List<string> qry = null;
        public List<string> docs = null;


        public Ranker(string path,bool isStem)
        {
            dataPath = path;
            if (!isStem) { postPath = @"\DisableStem"; } else { postPath = @"EnableStem"; }
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
        //public double BM25A(double tf, double numberOfDocuments, double docLength, double averageDocumentLength, double queryFrequency, double idf)
        //{

        //    double K = k1 * ((1 - b) + ((b * docLength) / averageDocumentLength));
        //    double weight = (((k1 + 1d) * tf) / (K + tf));	//first part
        //    weight = weight * (((k3 + 1) * queryFrequency) / (k3 + queryFrequency));  //second part
        //    // multiply the weight with idf 
        //    double idf2 = weight * Math.Log((numberOfDocuments - idf + 0.5) / (idf + 0.5));
        //    return idf2;
        //}
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
                using (StreamReade sr)
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
        public List<KeyValuePair<string, double>> rank(Dictionary<string, KeyValuePair<int, term.Type>> qries, HashSet<string> docs)
        {
            Dictionary<string, double> scoresBMOrigin = new Dictionary<string, double>();// ket is Document, value is score
            Dictionary<string, double> scoresB2 = new Dictionary<string, double>();// ket is Document, value is score
            int numOfDocs = 0;
            double avgDocLength = 0;
            string line;
            Dictionary<string, Dictionary<string,int>> terms = new Dictionary<string, Dictionary<string, int>>();//key=term, value=doc,tf
            Dictionary<string, List<string>> fin = new Dictionary<string, List<string>>(); // key = type, value=list of terms
            Dictionary<string, int> docSize = new Dictionary<string, int>(); //key= docName value = doc size
            using (StreamReader sr = new StreamReader(dataPath.Substring(0, dataPath.LastIndexOf('\\') + 1) + "\\documents.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (docs.Contains(line.Split('\t')[0])) { docSize.Add(line.Split('\t')[0], int.Parse(line.Split('\t')[6].Trim())); avgDocLength = avgDocLength + int.Parse(line.Split('\t')[6].Trim()); }
                }
            }
            int docamount = docSize.Count;
            avgDocLength = avgDocLength / docamount;
                /*
                 *  this part gest all the terms by type
                 */
                foreach (string q in qries.Keys)
            {
                if (qries[q].Value == term.Type.word)
                {
                    char c = char.ToUpper(q[0]);
                    string file = c <= 'Z' && c >= 'A' ? c+"" : "other";
                    if (!fin.ContainsKey(file))
                    {
                        List<string> x = new List<string>();
                        x.Add(q);
                        fin.Add(file, x);
                    }
                    else { fin[file].Add(q); }
                }
                else
                {
                    if (!fin.ContainsKey(qries[q].Value + ""))
                    {
                        List<string> x = new List<string>();
                        x.Add(q);
                        fin.Add(qries[q].Value + "", x);
                    }
                    else { fin[qries[q].Value + ""].Add(q); }
                }
            }
            /*
             * this part fills the terms Dictionary foreach term with the docs it shows up in acoording to the docs list
             */
            foreach (string str in fin.Keys)
            {
                using (StreamReader st = new StreamReader(dataPath + "\\" + str + "" + ".txt"))
                {
                    while ((line = st.ReadLine()) != null) {
                        string term = line.Split('\t')[0];
                        List<string> docsforTerms = line.Split('\t')[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        foreach(string x in docsforTerms)
                        {
                            if (!x.Contains('_')|| !docs.Contains(x.Substring(0, x.IndexOf('_')).Trim(' ')))
                            {
                                docsforTerms.Remove(x);
                            }
                        }
                        if (qries.ContainsKey(term))
                        {
                            Dictionary<string, int> tmp = new Dictionary<string, int>();
                            foreach (string doc in docsforTerms)
                            {
                                int y = doc.IndexOf('_');
                                string x = doc.Substring(doc.IndexOf('_')+1, doc.Length - 1- doc.IndexOf('_'));
                            if (terms.ContainsKey(term)){
                                terms[term].Add(doc.Substring(0, doc.IndexOf('_')).Trim(' '), int.Parse(doc.Substring(doc.IndexOf('_') + 1, doc.Length - 1 - doc.IndexOf('_'))));}
                            else {terms.Add(term, new  Dictionary<string, int>());terms[term].Add(doc.Substring(0, doc.IndexOf('_')).Trim(' '), int.Parse(doc.Substring(doc.IndexOf('_') + 1, doc.Length - 1 - doc.IndexOf('_'))));}
                            }
                        }
                    }
                }
            }
            /*
             * this part calculates the different variables for the equation
             */
            
            // int[] n = new int[qries.Count]; int i = 0;
            //int[] f = new int[qries.Count];
            //foreach (string x in qries.Keys)
            //{
            //    n[i] = terms[x].Count;
            //    f[i] = terms[x].Value
            //    i++;
            //}
            foreach (string docu in docs)
            {
                int docL = docSize[docu];
                double scoreTmp = 0;
                double scoreTmp2 = 0;
                foreach (string term in terms.Keys)
                {
                    int qf = qries[term].Key;
                    int nqi = terms[term].Count;
                    int N = docs.Count;
                    double IDF = Math.Log((N - nqi + 0.5) / (nqi) + 0.5);
                    Dictionary<string, int> x = terms[term];
                    int tf = 0;
                    if (!x.ContainsKey(docu)) {  tf = 0; }
                    else { tf = x[docu]; }
                    scoreTmp += IDF * (tf * (k1 + 1) / (tf + k1 * (1 - b + b * docL / avgDocLength)));
                    double ctd = tf / (1 - b + b * docL / avgDocLength);
                    scoreTmp2 += Math.Log((1 / ((nqi + 0.5) / (N - nqi + 0.5))) * ((k1 + 1) * tf / (k1 * (1 - b + b * docL / avgDocLength) + tf)) * ((1000 + 1) * qf / (1000 + qf)));
                }    
                scoresBMOrigin.Add(docu, scoreTmp);
                scoresB2.Add(docu, scoreTmp2);
            }
            var items = from pair in scoresBMOrigin
                        orderby pair.Value descending
                        select pair;
            List<KeyValuePair<string, double>> ans = new List<KeyValuePair<string, double>>();
            foreach (KeyValuePair<string,double> x in items)
            {
                ans.Add(x);
            }
            return ans;
        }

    }
}


