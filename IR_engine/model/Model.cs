using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

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
        public static int cores = Environment.ProcessorCount;
        public static int fileCount = 0;
        public static ConcurrentDictionary<string, byte> cityIn = new ConcurrentDictionary<string, byte>();
        public static ConcurrentDictionary<string, Location> locations = new ConcurrentDictionary<string, Location>();
        //end concurrent variables
        public static bool isWorking = false;
        Parse parser;
        Indexer indexer;
        ReadFile readfo;
        string path;
        bool ToStem;
        string IndexPath;
        string outPath;
        public Dictionary<string, indexTerm> indexList;

        public bool toStem { get => ToStem; set => ToStem = value; }
        public string Path { get { return path; }
            set
            {
                path = value;
                if (!IndexPath1.Equals(""))
                    indexer = new Indexer(IndexPath1, path);
            }
        }
        public string IndexPath1 { get => IndexPath;
            set
            {
                IndexPath = value;
                if (!Path.Equals(""))
                    indexer = new Indexer(IndexPath, Path);
            }
        }

        public Model(string path, bool Tostem, string ipath)
        {
            readfo = new ReadFile(path, Tostem, cores);
            this.path = path;
            this.IndexPath = ipath;
            this.toStem = Tostem;
            string outPath = null;
            //parser = new Parse(path, ToStem);
            if (toStem) { if (!File.Exists(IndexPath1 + "\\EnableStem")) { Directory.CreateDirectory(IndexPath1 + "\\EnableStem"); }outPath = IndexPath1 + "\\EnableStem"; }
            else {if (!File.Exists(IndexPath1 + "\\DisableStem")) { Directory.CreateDirectory(IndexPath1 + "\\DisableStem"); }outPath = IndexPath1 + "\\DisableStem";}
            indexer = new Indexer(outPath, path+ "\\Posting_and_indexes");
            indexList = new Dictionary<string, indexTerm>();
        }

        public Model()
        {
            indexList = new Dictionary<string, indexTerm>();
            toStem = false;
            indexer = null;
            IndexPath = "";
            path = "";
        }

        public void index()
        {
            if(Path.Equals("") || IndexPath1.Equals(""))
            {
                MessageBox.Show("Invalid path");
                return;
            }
            isWorking = true;
            readfo = new ReadFile(path, toStem, cores);
            if (toStem) { if (!File.Exists(IndexPath1 + "\\EnableStem")) { Directory.CreateDirectory(IndexPath1 + "\\EnableStem"); } outPath = IndexPath1 + "\\EnableStem"; }
            else { if (!File.Exists(IndexPath1 + "\\DisableStem")) { Directory.CreateDirectory(IndexPath1 + "\\DisableStem"); } outPath = IndexPath1 + "\\DisableStem"; }
            indexer = new Indexer(outPath, path + "\\Posting_and_indexes");

            if (!Directory.Exists(path + "\\cityIndex")) { Directory.CreateDirectory(path + "\\cityIndex"); }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            isWorking = true;
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
            using (StreamWriter ct = new StreamWriter(Path + "\\city_dictionary.txt"))
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
                        manageResources();
                        using (StreamWriter sw = new StreamWriter(Path + "\\Posting_and_indexes\\index" + chunk + ".txt"))
                        {
                            foreach (KeyValuePair<term, term> entry in terms2)
                            {
                                sw.WriteLine(entry.Key.ToString());
                            }
                        }
                        using (StreamWriter sw2 = new StreamWriter(path + "\\cityIndex\\city"+ chunk + ".txt"))
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
                using (StreamWriter sw = new StreamWriter(Path + "\\Posting_and_indexes\\index" + chunk + ".txt"))
                {
                    foreach (KeyValuePair<term, term> entry in terms2)
                    {
                        sw.WriteLine(entry.Key.ToString());
                    }
                }
                using( StreamWriter sw2 = new StreamWriter(path+ "\\cityIndex\\city" + chunk + ".txt"))
                {
                    foreach(KeyValuePair<Location,Location> loc in megaLocList)
                    {
                        sw2.WriteLine(loc.Key.ToString());
                    }
                }
                terms2.Clear();
                Console.WriteLine("{0} tasks done, total done: {1}", tasks, id);
                t = null;
                chunk++;
            }
            indexList = indexer.CreateIndex();
            Directory.Delete(Path + "\\Posting_and_indexes");
            indexer.MergeLocations(path + @"\cityIndex");
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            MessageBox.Show("Done indexing the curpus!\nPorking time: "+double.Parse(elapsedMs.ToString())/1000.0/60.0+" min", "DONE!");
            isWorking = false;
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
            using (StreamWriter sw = new StreamWriter(path + "\\documents.txt", true))
            {
                foreach (KeyValuePair<string, document> entry in docs)
                {
                    sw.WriteLine(entry.Value.ToString());
                }
            }
            docs.Clear();
        }

        public Dictionary<string, indexTerm> getDictionary()
        {
            return indexList;
        }
        public Dictionary<string, indexTerm> load_index(string indexPath)
        {
            indexList = Indexer.Load_Index(indexPath);
            return indexList;
        }
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
        public void Memorydump()
        {
            queueList.Clear();
            locsList.Clear();
            megaLocList.Clear();
            foreach(term t in terms2.Values)
            {
                t.posting.Clear();
            }
            terms2.Clear();
            docs.Clear();
            cityIn.Clear();
            foreach(Location l in locations.Values)
            {
                l.LocationsInDocs.Clear();
            }
            locations.Clear();
            if(parser!=null)
                parser.stopwords.Clear();
            if(readfo!=null)
            readfo.allfiles.Clear();
        }
    }
}


