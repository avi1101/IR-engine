using System;
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
        private static Dictionary<string, KeyValuePair<int, term.Type>> currentKeywords = new Dictionary<string, KeyValuePair<int, term.Type>>();
        public static List<KeyValuePair<string, term.Type>> parsed = new List<KeyValuePair<string, term.Type>>();
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

        //string[] returnedDocs = new string[50]; //amount of returned documents is restricted to 50
        //string[] entities = new string[5]; //amount of entities is restricted to 5
        //List<string> docsIncities = new List<string>(); //the docs we want to search in

        //public void search(string query, List<string> cities, string dataPath)
        //{
        //    string[] qry = query.Split(' ');
        //    string line;
        //    HashSet<string> ctHash = new HashSet<string>();
        //    foreach (string city in cities)
        //    {
        //        ctHash.Add(city);
        //    }
        //    if (cities != null && cities.Count > 0)
        //    {
        //        using (StreamReader st = new StreamReader(dataPath + "\\documents.txt"))
        //        {
        //            while ((line = st.ReadLine()) != null)
        //                if (ctHash.Contains(line.Split('\t')[4]))
        //                    docsIncities.Add(line.Split('\t')[0]);
        //        }

        //    }
        //    else
        //    {
        //        using (StreamReader st = new StreamReader(dataPath + "\\documents.txt"))
        //        {
        //            while ((line = st.ReadLine()) != null)
        //                docsIncities.Add(line.Split('\t')[0]);
        //        }
        //    }
        //    //TODO: send list of docs to rank
        //}

        /// <summary>
        /// will search and recover all docs that may be relevant to the queries
        /// </summary>
        /// <param name="toStem"></param>
        /// <returns></returns>
        public void Search(List<string> matching, bool toStem)
        {
            List<query> queries = new List<query>();
            // dictionary of <queryID, dictionary of <parsed query, occrenced>>
            Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>> parsedQueires = parseAllQueires(matching, toStem);
            foreach(var q in parsedQueires)
            {

            }
        }

        private Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>> parseAllQueires(List<string> matching, bool toStem)
        {
            Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>> qs =
                new Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>>();
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
                    currentKeywords = new Dictionary<string, KeyValuePair<int, term.Type>>();
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
            foreach (var pair in parsed)
            {
                string word = pair.Key;
                if (!string.IsNullOrWhiteSpace(word) && !(word[0] == '<'))
                {
                    String result = ProcessWord(word, toStem);
                    if (!result.Equals(""))
                    {
                        if(currentKeywords.ContainsKey(result))
                        {
                            int occ = currentKeywords[result].Key;
                            currentKeywords[result] = new KeyValuePair<int, term.Type>(occ + 1, pair.Value);
                        }
                        else
                        {
                            currentKeywords.Add(result, new KeyValuePair<int, term.Type>(1, pair.Value));
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
