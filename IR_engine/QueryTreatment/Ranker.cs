﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine.QueryTreatment
{
    class Ranker
    {
        public double k1 = 1.2;
        public double k3 = 8;
        public double b=0.75;
        public double delta = 1.0;   //TODO: change and check

        public List<string> qry=null;
        public List<string> docs = null;


        Ranker(List<string> qry, List<string> docs)
        {
            this.qry = qry;
            this.docs = docs;
        }
        /// <summary>
        /// Uses BM25 to compute a weight for a term in a document.
        /// </summary>
        /// <param name="tf">The term frequency in the document</param>
        /// <param name="numberOfDocuments">number of documents in corpus</param>
        /// <param name="docLength">the document's length</param>
        /// <param name="averageDocumentLength">average document length</param>
        /// <param name="queryFrequency"></param>
        /// <param name="documentFrequency"></param>
        /// <returns></returns>
        public double BM25A(double tf, double numberOfDocuments, double docLength, double averageDocumentLength,double queryFrequency,double documentFrequency)
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
        /// <param name="documentFrequency">the frequency of searching term in the document to rank</param>
        /// <param name="docLength"> the size of document to rank</param>
        /// <param name="averageDocumentLength">the average size of documents in the corpus</param>
        /// <param name="numberOfDocuments">number of documents in the corpus</param>
        /// <param name="documentFrequency">number of documents containing the given term in the corpus</param>
        /// <returns></returns>
        public double BM25B(double tf, int docLength, double averageDocumentLength, long numberOfDocuments, long documentFrequency)
        {
            if (tf <= 0) return 0.0;
            double tf2 = tf * (k1 + 1) / (tf + k1 * (1 - b + b * docLength / averageDocumentLength));
            double idf = Math.Log((numberOfDocuments - documentFrequency + 0.5) / (documentFrequency + 0.5));

            return (tf2+delta) * idf;
        }

        public double BM25P(List<string> qry, List<string> docs)
        {
            double ans = 0;
            foreach(string q in qry)
            {
                ans=ans+Math.Log((docs.Count-1)/qry.)
            }



        }
    }
}
