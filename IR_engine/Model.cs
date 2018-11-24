using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NSoup;
using NSoup.Nodes;
using System.ComponentModel;
using System.Collections.Concurrent;

namespace IR_engine
{
    class Model
    {
        //concurrent variables
        static int i = 0;                                                           //use to index the queues in the list
        public static List<ConcurrentQueue<term>> queueList = new List<ConcurrentQueue<term>>();        //list of Queues 
        public static Dictionary<term, term> terms2 = new Dictionary<term, term>(); //the dictionary
        //end concurrent variables

        Parse parser;
        ReadFile readfo;
        string path;
        bool ToStem;
        public double elapsedMsdouble;

        public Model(string path, bool Tostem)
        {

            readfo = new ReadFile(path);
            this.path = path;
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
            int tasks = Environment.ProcessorCount - 4;             //get the number of logical proccesors 
            //int tasks = 1;             //get the number of logical proccesors 
            for (int ch = 0; ch < tasks; ch++)                  //initialize the queues
                queueList.Add(new ConcurrentQueue<term>());
            int k = 0, chunk = 0, id = 0;
            foreach(string file in files)
            {
                t = new List<Task>();
                t.Add(Task.Factory.StartNew(() => {
                    readfo.readfile(file, (i++ % tasks));
                }));
                id++;
                k++;
                if (k % tasks == 0)
                    chunk++;
                if (k % tasks == 0)
                {
                    Console.WriteLine("awaiting {0} tasks to finish", tasks);
                    foreach (Task ts in t)
                        ts.Wait();
                    manageResources();
                    using (StreamWriter sw = new StreamWriter(path+ "\\Posting_and_indexes\\index" + chunk + ".txt"))
                    {
                        foreach (KeyValuePair<term, term> entry in terms2)
                        {
                            sw.WriteLine(entry.Key.Phrase + "\t" + entry.Value.IsUpperInCurpus + '\t' + entry.Value.printPosting());
                        }
                    }
                    terms2.Clear();
                    Console.WriteLine("{0} tasks done, total done: {1}", tasks, id);
                }
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time: " + elapsedMs);
        }

        public void manageResources()
        {
            //while (!stop)
            //{
            //semaphore.WaitOne();
            for (int i = 0; i < queueList.Count; i++)
            {
                term t = null;
                for (int j = 0; j < queueList[i].Count; j++)
                {
                    int len = queueList[i].Count;
                    queueList[i].TryDequeue(out t);
                    if (t == null) break;
                    if (terms2.ContainsKey(t))
                    {
                        terms2[t].idf += 1;
                        if (!Parse.DocName.Equals(""))
                            terms2[t].AddToPosting(Parse.DocName);
                    }
                    else
                    {
                        if (!Parse.DocName.Equals(""))
                            t.AddToPosting(Parse.DocName);
                        terms2.Add(t, t);
                    }
                }
            }
            //}
            //Console.WriteLine("end");
        }

        public Dictionary<string, term> getDictionary()
        {
            return Parse.terms;
        }
    }

}
    

