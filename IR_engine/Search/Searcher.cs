using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word2vec.Tools;
using System.Collections.Concurrent;
using System.Threading;

namespace IR_engine
{
    class Searcher
    {
        HashSet<string> stopwords = new HashSet<string>() {
            "a","an","and","also","all","are","as","at","be","been","by","but","for","from",
            "have","has","had","he","in","is","it","its","more","new","not","what", "where",
            "which", "how", "who", "of","on","page","part","that","the","this",
            "to","s","was","were","will","with", "documents", "i.e.", "i.e.,"};
        private static Dictionary<string, KeyValuePair<int, term.Type>> currentKeywords = new Dictionary<string, KeyValuePair<int, term.Type>>();
        public static List<KeyValuePair<string, term.Type>> parsed = new List<KeyValuePair<string, term.Type>>();
        Mutex m = new Mutex();
        static Dictionary<int, string> Index2Doc = new Dictionary<int, string>();
        Dictionary<string, indexTerm> index;
        bool Semantics;
        bool toStem;
        Ranker ranker;
        string indexPath;
        string queryPath;
        string modelPath;
        Vocabulary vocabulary;

        public Searcher(string indexPath, string queryPath, bool Semantics, string modelPath, bool toStem)
        {
            this.indexPath = indexPath;
            this.queryPath = queryPath;
            this.Semantics = Semantics;
            this.modelPath = modelPath;
            this.toStem = toStem;
            this.ranker = new Ranker(indexPath, toStem);
            try
            {
                vocabulary = new Word2VecBinaryReader().Read(modelPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown model");
                vocabulary = null;
            }
            if (Index2Doc.Count == 0)
            {
                using (StreamReader city = new StreamReader(indexPath.Substring(0, indexPath.LastIndexOf('\\') + 1) + "\\documents.txt"))
                {                                   //locations list is a list of not desired locations
                    string line = "";
                    while ((line = city.ReadLine()) != null)
                    {
                        string[] splitted = line.Split('\t');
                        Index2Doc.Add(int.Parse(splitted[0]), splitted[1]);
                    }
                }
            }
        }

        public void loadIndex(Dictionary<string, indexTerm> index)
        {
            this.index = index;
        }

        public Searcher(bool semantics, string modelPath, string indexPath)
        {
            Semantics = semantics;
            this.indexPath = indexPath;
            this.modelPath = modelPath;
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
        public void Search(List<string> locations)
        {
            // dictionary of <queryID, dictionary of <parsed query, <occrences, type>>>
            Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>> parsedQueires = parseAllQueires();
            // dictionary of <queryID, list of <document, it's rank>>
            ConcurrentDictionary<int, List<KeyValuePair<string, double>>> ranks = 
                new ConcurrentDictionary<int, List<KeyValuePair<string, double>>>();
            HashSet<string> ctHash = new HashSet<string>();
            HashSet<string> docs = new HashSet<string>();
            foreach (string city in locations)
            {
                ctHash.Add(city);
            }

            using (StreamReader city = new StreamReader(indexPath.Substring(0, indexPath.LastIndexOf('\\') + 1) + "\\documents.txt"))
            {                                   //locations list is a list of not desired locations
                string line = "";
                while((line = city.ReadLine()) != null)
                {
                    string[] splitted = line.Split('\t');
                    if (!ctHash.Contains(splitted[5]))
                        docs.Add(splitted[0]);  //change 0 to 1 if needed name and not index

                }
            }
            Parallel.ForEach(parsedQueires, (q) =>
            {
                m.WaitOne();
                if (Semantics)
                {
                    var recWords = GetSimilar(q.Value);
                    foreach (KeyValuePair<string, int> w in recWords)
                    {
                        if (q.Value.ContainsKey(w.Key))
                        {
                            int num = q.Value[w.Key].Key;
                            term.Type t = q.Value[w.Key].Value;
                            q.Value[w.Key] = new KeyValuePair<int, term.Type>(w.Value + num, t);
                        }
                        else
                        {
                            foreach (KeyValuePair<string, term.Type> e in parsed)
                                if (e.Key.Equals(w.Key))
                                {
                                    q.Value.Add(w.Key, new KeyValuePair<int, term.Type>(w.Value, e.Value));
                                    parsed.Remove(e);
                                    break;
                                }
                        }
                    }
                }
                m.ReleaseMutex();
                // LocationName \t doc | loc1 | loc2 | , doc | loc1 | loc2 | , .....
                ranks.TryAdd(q.Key, ranker.rank(q.Value, docs));
            });
            //foreach (var q in parsedQueires)
            //{
            //    if (Semantics)
            //    {
            //        var recWords = GetSimilar(q.Value);
            //        foreach(KeyValuePair<string, int> w in recWords)
            //        {
            //            if(q.Value.ContainsKey(w.Key))
            //            {
            //                int num = q.Value[w.Key].Key;
            //                term.Type t = q.Value[w.Key].Value;
            //                q.Value[w.Key] = new KeyValuePair<int, term.Type>(w.Value + num, t);
            //            }
            //            else
            //            {
            //                foreach(KeyValuePair<string, term.Type> e in parsed)
            //                    if(e.Key.Equals(w.Key))
            //                    {
            //                        q.Value.Add(w.Key, new KeyValuePair<int, term.Type>(w.Value, e.Value));
            //                        parsed.Remove(e);
            //                        break;
            //                    }
            //            }
            //        }
            //    }
            //    // LocationName \t doc | loc1 | loc2 | , doc | loc1 | loc2 | , .....
            //    ranks.TryAdd(q.Key, ranker.rank(q.Value, docs));
            //}
            using (StreamWriter sw = new StreamWriter(indexPath.Substring(0, indexPath.LastIndexOf('\\') + 1) + "res.txt"))
            {
                foreach(KeyValuePair<int, List<KeyValuePair<string, double>>> ret in ranks)
                {
                    int num = 0;
                    foreach(KeyValuePair<string, double> DocRank in ret.Value)
                    {
                        if (num >= 50 || DocRank.Value == 0) break;
                        sw.WriteLine(   ret.Key + " "
                                        + 0 + " "
                                        + Index2Doc[int.Parse(DocRank.Key)].Replace(" ", "") + " "
                                        + num + " "
                                        + DocRank.Value + " "
                                        + "run"    );
                        num++;
                    }
                }
            }
        }

        private Dictionary<string, int> GetSimilar(Dictionary<string, KeyValuePair<int, term.Type>> words)
        {
            if (vocabulary == null) return null;
            Dictionary<string, int> recommendedWords = null;
            recommendedWords = new Dictionary<string, int>();
            HashSet<string> commonWords = new HashSet<string>();
            foreach (KeyValuePair<string, KeyValuePair<int, term.Type>> word in words)
            {
                //gets the vector (size 20) of the word
                var dist = vocabulary.Distance(word.Key, 20);
                //build vocabulary to find duplicates, duplicates gets inside the recommended list
                for (int i = 0; i < dist.Length; i++)
                {
                    string w = dist[i].Representation.WordOrNull;
                    if (commonWords.Contains(w))
                    {
                        if (!recommendedWords.ContainsKey(w))
                            recommendedWords.Add(w, 1);
                        else
                            recommendedWords[w]++;
                    }
                    else
                    {
                        commonWords.Add(w);
                    }
                }
                //adding first 5 (if any) terms with the highest probability according to the vector
                //willl search them anyway because they have the highest probability
                for (int i = 0; i < dist.Length; i++)
                {
                    if (i == 5) break;
                    if (!recommendedWords.ContainsKey(dist[i].Representation.WordOrNull))
                        recommendedWords.Add(dist[i].Representation.WordOrNull, 1);
                    else
                        recommendedWords[dist[i].Representation.WordOrNull]++;
                }
            }
            parsed.Clear();
            new Parse("", toStem).parseText(commonWords.ToArray(), -1);
            return recommendedWords;
        }

        /*
         *        
         *        distance between 2 vectors

            var vocabulary = new Word2VecBinaryReader().Read(outputFileName);
            while (true)
            {
                Console.WriteLine("distance of 2 word vector:");
                string word1 = Console.ReadLine();
                string word2 = Console.ReadLine();
                float[] vector1 = vocabulary[word1].NumericVector;
                float[] vector2 = vocabulary[word2].NumericVector;
                double dist = 0;
                for (int i = 0; i < vector2.Length; i++)
                    dist += Math.Pow(vector1[i] - vector2[i], 2);
                dist = Math.Sqrt(dist);
                Console.WriteLine("Distance is: " + dist);
            }
         */

        private Dictionary<int, Dictionary<string, KeyValuePair<int, term.Type>>> parseAllQueires()
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
                    ParseLine(line.Substring(8));
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
                    foreach (string l in narrLines)
                    {
                        if (l.Contains("not relevant") || l.Contains("non-relevant"))
                            continue;
                        ParseLine(line);
                    }
                    //if (matching != null && Semantics)
                    //{
                    //    foreach (string s in matching)
                    //        ParseLine(s);
                    //}
                    qs.Add(currentID, currentKeywords);
                    currentID = 0;
                    currentKeywords = new Dictionary<string, KeyValuePair<int, term.Type>>();
                }
                else
                {
                    if (last.Equals("desc") && Semantics)
                    {
                        ParseLine(line);
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

        private void ParseLine(String line)
        {
            Parse p = new Parse("", toStem);
            p.parseText(line.Split(' '), -1);
            foreach (var pair in parsed)
            {
                string word = pair.Key;
                if (!string.IsNullOrWhiteSpace(word) && !(word[0] == '<'))
                {
                    String result = ProcessWord(word);
                    if (!result.Equals(""))
                    {
                        if (currentKeywords.ContainsKey(result))
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

        private String ProcessWord(String word)
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
