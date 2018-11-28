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
        public static Dictionary<term, term> terms2 = new Dictionary<term, term>(); //the dictionary
        public static int cores = Environment.ProcessorCount/2;
        public static int fileCount = 0;
        //end concurrent variables

        Parse parser;
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
            parser = new Parse(path, ToStem);
        }


        public void index()
        {
            // step one, the parsing
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int filesNum = readfo.returnSize();
            bool hasIndex = File.Exists(path + "\\index_elad_avi.txt");
            //if (hasIndex == true)
            //{
            //    /**
            //     * add a pop up window to ask whether to re-index the docs in the folder
            //    **/
            //}
            //else
            //{
            //    File.CreateText(path + "\\index_elad_avi.txt");
            //}
            //for (int i = 0; i < readfo.returnSize(); i++)
            //{
            //    List<document> f = readfo.getDocs();
            //    if (f == null) continue;
            //    for(int j = 0; j < f.Count; j++)
            //    {
            //        parser.Text2list(f[j]);
            //    }
            //}
            List<Task> t;
            List<string> files = readfo.allfiles;               //gets the files list
            int tasks = cores;                                  //get the number of logical proccesors 
            //int tasks = 1;             //get the number of logical proccesors 
            for (int ch = 0; ch < tasks; ch++)                  //initialize the queues
                queueList.Add(new Dictionary<string, term>());
            int k = 0, chunk = 0, id = 0;
            t = new List<Task>();
            foreach (string file in files)
            {
                int tsk = i % tasks;
                t.Add(Task.Factory.StartNew(() => {
                    readfo.readfile(file, tsk);
                }));
                id++;
                i++;
                k++;
                if (k % tasks == 0)
                {
                    Console.WriteLine("awaiting {0} tasks to finish", tasks);
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
                                sw.WriteLine(entry.Key.Phrase + "\t" + entry.Value.IsUpperInCurpus + '\t' + entry.Value.printPosting());
                            }
                        }
                        terms2.Clear();
                        chunk++;
                    }
                    Console.WriteLine("{0} tasks done, total done: {1}", tasks, id);
                    t = new List<Task>();
                }
            }

            {
                Console.WriteLine("awaiting {0} tasks to finish", tasks);
                foreach (Task ts in t)
                    ts.Wait();
                manageResources();
                using (StreamWriter sw = new StreamWriter(path + "\\Posting_and_indexes\\index" + chunk + ".txt"))
                {
                    foreach (KeyValuePair<term, term> entry in terms2)
                    {
                        sw.WriteLine(entry.Key.Phrase + "\t" + entry.Value.IsUpperInCurpus + '\t' + entry.Value.printPosting());
                    }
                }
                terms2.Clear();
                Console.WriteLine("{0} tasks done, total done: {1}", tasks, id);
                t = null;
                chunk++;
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time: " + elapsedMs);
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
        }

        //public void manageResources()
        //{
        //    Int32 len = 0;
        //    for (int i = 0; i < queueList.Count; i++)
        //    {
        //        Int32 j;
        //        term t = null;
        //        len = queueList[i].Count;
        //        for (j = 0; j < len; j++)
        //        {
        //            queueList[i].TryRemove(out t);
        //            if (t == null) break;
        //            if (terms2.ContainsKey(t))
        //            {
        //                terms2[t].idf += 1;
        //            }
        //            else
        //            {
        //                terms2.Add(t, t);
        //            }
        //        }
        //    }
        //}

        public Dictionary<string, term> getDictionary()
        {
            return Parse.terms;
        }
    }

}


