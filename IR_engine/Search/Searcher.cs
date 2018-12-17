﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IR_engine
{
    class Searcher
    {
        HashSet<string> stopwords = new HashSet<string>() { "a","an","and","also","all","are","as","at","be","been","by","but","for","from",
            "have","has","had","he","in","is","it","its","more","new","not","what", "where", "which", "how", "who",
            "of","on","page","part","that","the","this",
            "to","s","was","were","will","with"};
        private static Dictionary<string, int> currentKeywords = new Dictionary<string, int>();
        public static List<string> parsed = new List<string>();
        Dictionary<string, indexTerm> index;
        bool Semantics;
        Ranker ranker;
        string indexPath;
        string queryPath;
        struct query
        {
            string title;
            string desc;
            string nerr;
            List<string> otherMatchingWords;
        }

        public Searcher(string indexPath, string queryPath, bool Semantics)
        {
            this.indexPath = indexPath;
            this.queryPath = queryPath;
            this.Semantics = Semantics;
        }

        public void loadIndex(Dictionary<string, indexTerm> index)
        {
            this.index = index;
        }

        public Searcher(bool semantics, string indexPath)
        {
            Semantics = semantics;
            this.indexPath = indexPath;
            this.queryPath = "";
        }
        /// <summary>
        /// will search and recover all docs that may be relevant to the queries
        /// </summary>
        /// <param name="toStem"></param>
        /// <returns></returns>
        public void Search(List<string> matching, bool toStem)
        {
            List<query> queries = new List<query>();
            // dictionary of <queryID, dictionary of <parsed query, occrenced>>
            Dictionary<int, Dictionary<string, int>> parsedQueires = parseAllQueires(matching, toStem);

        }

        private Dictionary<int, Dictionary<string, int>> parseAllQueires(List<string> matching, bool toStem)
        {
            Dictionary<int, Dictionary<string, int>> qs = new Dictionary<int, Dictionary<string, int>>();
            List<string> content = File.ReadAllLines(queryPath).ToList();
            int currentID = 0;
            string last = "";
            StringBuilder narr = new StringBuilder();
            foreach (var line in content)
            {
                // start of topic
                if (line.StartsWith("<num>"))
                {
                    currentID = int.Parse(line.Substring(14));
                }
                else if (line.StartsWith("<title>"))
                {
                    ParseLine(line.Substring(8), toStem);
                }
                else if (line.StartsWith("<desc>"))
                {
                    last = "desc";
                }
                else if (line.StartsWith("<narr>"))
                {
                    last = "narr";
                }

                // end of topic
                else if (line.StartsWith("</top>"))
                {
                    string[] narrLines = narr.ToString().Split('.');
                    foreach(string l in narrLines)
                    {
                        if (l.Contains("not relevant") || l.Contains("non-relevant"))
                            continue;
                        ParseLine(line, toStem);
                    }
                    if (matching != null && Semantics)
                    {
                        foreach (string s in matching)
                            ParseLine(s, toStem);
                    }
                    qs.Add(currentID, currentKeywords);
                    currentID = 0;
                    currentKeywords = new Dictionary<string, int>();
                }
                else
                {
                    if (last.Equals("desc") && Semantics)
                    {
                        ParseLine(line, toStem);
                    }
                    else if (last.Equals("narr") && Semantics)
                    {
                        //ParseLine(line, toStem);
                        narr.Append(line + " ");
                    }
                }
            }
            return qs;
        }

        private void ParseLine(String line, bool toStem)
        {
            Parse p = new Parse("", toStem);
            p.parseText(line.Split(' '), 0);
            foreach (var word in parsed)
            {
                if (!string.IsNullOrWhiteSpace(word) && !(word[0] == '<'))
                {
                    String result = ProcessWord(word, toStem);
                    if (!result.Equals(""))
                    {
                        if(currentKeywords.ContainsKey(result))
                        {
                            currentKeywords[result]++;
                        }
                        else
                        {
                            currentKeywords.Add(result, 1);
                        }
                    }
                }
            }
            parsed.Clear();
        }

        private String ProcessWord(String word, bool toStem)
        {
            String workingCopy = word;

            // check if stemmed is stop word, do not search complete list if not necessary
            if ((workingCopy.Length <= 4) && stopwords.Contains(workingCopy))
            {
                return "";
            }

            // stem the word
            var stemmer = new IR_engine.stem.Stemmer();
            char[] temp = workingCopy.ToCharArray();
            stemmer.add(temp, temp.Length);
            if (toStem)
            {
                stemmer.stem();
            }
            else
            {
                stemmer.doNotStem();
            }
            return stemmer.ToString();
        }

        //private static bool IsStopword(String toCheck)
        //{
        //    foreach (var temp in _stopWords)
        //    {
        //        if (toCheck.Equals(temp))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}