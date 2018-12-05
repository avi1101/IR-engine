using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Threading;

namespace IR_engine
{
    class Model
    {
        //concurrent variables
        static int i = 0;                                                           //use to index the queues in the list
        public static List<Dictionary<string, term>> queueList = new List<Dictionary<string, term>>();        //list of Queues 
        public static List<Dictionary<string, Location>> locsList = new List<Dictionary<string, Location>>();
        public static Dictionary<Location, Location> megaLocList = new Dictionary<Location, Location>();
        public static Dictionary<term, term> terms2 = new Dictionary<term, term>(); //the dictionary
        public static ConcurrentDictionary<string, document> docs = new ConcurrentDictionary<string, document>(); //holds doc names and <max TF, distinct, location>
        public static int cores = Environment.ProcessorCount/2;
        public static int fileCount = 0;
        public static ConcurrentDictionary<string, byte> cityIn = new ConcurrentDictionary<string, byte>();
        public static ConcurrentDictionary<string, Location> locations = new ConcurrentDictionary<string, Location>();
        //end concurrent variables
        Parse parser;
        Indexer indexer;
        ReadFile readfo;
        string path;
        bool ToStem;
        public double elapsedMsdouble;
        string IndexPath;

        public Model(string path, bool Tostem, string ipath)
        {

            readfo = new ReadFile(path, Tostem, cores);
            this.path = path;
            this.IndexPath = ipath;
            this.ToStem = Tostem;
            string outPath = null;
            //parser = new Parse(path, ToStem);
            if (ToStem) { if (!File.Exists(IndexPath + "\\EnableStem")) { Directory.CreateDirectory(IndexPath + "\\EnableStem"); }outPath = IndexPath + "\\EnableStem"; }
            else {if (!File.Exists(IndexPath + "\\DisableStem")) { Directory.CreateDirectory(IndexPath + "\\DisableStem"); }outPath = IndexPath + "\\DisableStem";}
            indexer = new Indexer(outPath, path+ "\\Posting_and_indexes");
            Directory.CreateDirectory(path + "\\Posting_and_indexes\\cityIndex");
        }
        public void index()
        {
            // step one, the parsing
            int filesNum = readfo.returnSize();
            // bool hasIndex = File.Exists(path + "\\index_elad_avi.txt");

            List<Task> t;
            List<string> files = readfo.allfiles;               //gets the files list
            int tasks = cores;                                  //get the number of logical proccesors 
            //int tasks = 1;             //get the number of logical proccesors 
            for (int ch = 0; ch < tasks; ch++)
            {                  //initialize the queues
                queueList.Add(new Dictionary<string, term>());
                locsList.Add(new Dictionary<string, Location>());
            }
            int k = 0, chunk = 0, id = 0;
            t = new List<Task>();
            createCityDic(files);
            for(int i=0;i< locsList.Count; i++) { }
            var list = locations.Keys.ToList();
            list.Sort();
            using (StreamWriter ct = new StreamWriter(path + "\\city_dictionary.txt"))
            {
                foreach(var key in list)
                {
                    ct.WriteLine(key + "\t" + locations[key].Country + "\t" + locations[key].Currency + "\t" + locations[key].Population);
                }
            }

            foreach (string file in files)
            {
                int tsk = i % tasks;
                t.Add(Task.Factory.StartNew(() =>
                {
                    readfo.readfile(file, tsk);
                }));
                id++;
                i++;
                k++;
                if (k % tasks == 0)
                {
                    foreach (Task ts in t)
                        ts.Wait();
                    if (k % (tasks * 5) == 0)
                    {
                        Console.WriteLine("Memory cleanup");
                        manageResources();
                        using (StreamWriter sw = new StreamWriter(path + "\\Posting_and_indexes\\index" + chunk + ".txt"))
                        {
                            foreach (KeyValuePair<term, term> entry in terms2)
                            {
                                sw.WriteLine(entry.Key.ToString());
                            }
                        }
                        using (StreamWriter sw2 = new StreamWriter(path + "\\Posting_and_indexes\\cityIndex\\city"+ chunk + ".txt"))
                        {
                           // Console.WriteLine("megaLocList "+ megaLocList.Count);
                            foreach (KeyValuePair<Location, Location> loc in megaLocList)
                            {
                                sw2.WriteLine(loc.Key.ToString());
                            }
                        }
                        terms2.Clear();
                        chunk++;
                    }
                    t = new List<Task>();
                }
            }
            {
                foreach (Task ts in t)
                    ts.Wait();
                manageResources();
                using (StreamWriter sw = new StreamWriter(path + "\\Posting_and_indexes\\index" + chunk + ".txt"))
                {
                    foreach (KeyValuePair<term, term> entry in terms2)
                    {
                        sw.WriteLine(entry.Key.ToString());
                    }
                }
                using( StreamWriter sw2 = new StreamWriter(path+ "\\Posting_and_indexes\\cityIndex\\city" + chunk + ".txt"))
                {
                    foreach(KeyValuePair<Location,Location> loc in megaLocList)
                    {
                     //   Console.WriteLine("megaLocList"+ megaLocList.Count);
                        sw2.WriteLine(loc.Key.ToString());
                    }
                }
                terms2.Clear();
                Console.WriteLine("{0} tasks done, total done: {1}", tasks, id);
                t = null;
                chunk++;
            }

        }

        public void manageResources()
        {
            for (int i = 0; i < queueList.Count; i++)
            {
                term t = null;
                foreach (KeyValuePair<string, term> entry in queueList[i])
                {
                    t = entry.Value;
                    if (t == null) break;
                    //queueList[i].TryRemove(t.Phrase, out t);
                    if (terms2.ContainsKey(t))
                    {
                        terms2[t].AddToPosting(t.posting);
                    }
                    else
                    {
                        terms2.Add(t, t);
                    }

                }
                queueList[i].Clear();
            }
            for(int i = 0; i < locsList.Count; i++)
            {
                Location l = null;
                foreach(KeyValuePair<string, Location> entry in locsList[i])
                {
                    l = entry.Value;
                    if (l == null) break;
                    if (megaLocList.ContainsKey(l))
                    {
                        megaLocList[l].addOccurs(l.LocationsInDocs);
                    }
                    else
                    {
                        megaLocList.Add(l, l);
                    }
                }
                locsList[i].Clear();
            }
            using (StreamWriter sw = new StreamWriter(path + "\\Posting_and_indexes\\documents.txt", true))
            {
                foreach (KeyValuePair<string, document> entry in docs)
                {
                    sw.WriteLine(entry.Value.ToString());
                }
            }
            docs.Clear();
        }

        public Dictionary<string, term> getDictionary()
        {
            return null;
        }

        //public bool hasIndex()
        //{
        //    return Directory.Exists(path + "\\Posting_and_indexes");
        //}

        public static void createCityDic( List<string> files)
        {
            List<Task> lst = new List<Task>();
            int tasks = cores;
            foreach (string fileRaw in files)
            {
                {
                    int tsk = i % tasks;
                    lst.Add(Task.Factory.StartNew(() =>
                    {
                        int idx = 0;
                        string DAfile = File.ReadAllText(fileRaw);
                        int end = 0, st = 0;
                        while (true)
                        {
                            st = DAfile.IndexOf("<F P=104>", idx);
                            if (st != -1)
                            {
                                end = DAfile.IndexOf("</F>", st, 100);
                            }
                            else { break; }
                            string city = "";
                            if (st != -1 && end != -1) { city = (DAfile.Substring(st + 9, (end - st) - 9)); idx = end; }
                            else { break; }
                            string[] fullname = city.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (fullname.Length < 1) continue;
                            string F = ReadFile.rmvStr(fullname[0]).ToLower();
                            if (!hasNum(F))
                            {
                                if (!cityIn.ContainsKey(F))
                                {
                                    cityIn.TryAdd(F, 0);
                                    ReadFile.addLocation(F);
                                }
                            }
                        }
                    }));
                    i++;
                    if (tsk == 0)
                    {
                        foreach (Task ts in lst)
                            ts.Wait();
                        lst.Clear();
                    }
                }
            }
        }
        static bool hasNum(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (Char.IsDigit(word[i]) || Char.IsDigit(word[word.Length - i - 1]))
                    return true;
            }
            return false;
        }
        public static string cleanAll(string word)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
               
                char c = word[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                    sb.Append(c);
                if(c==' ' && sb.Length > 0)
                {
                    return sb.ToString(); ;
                }
            }
            return sb.ToString();
        }
    }
}


