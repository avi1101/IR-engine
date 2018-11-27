using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class Indexer
    {
        string ipath;

        public Indexer(string ipath)
        {
            this.ipath = ipath;
        }

        /// <summary>
        /// this method creates an index file in the given directory and returns 
        /// a dictionary of terms and file pointer
        /// </summary>
        /// <param name="path"> the path to the unproccessed index files the Parser creates</param>
        /// <returns> a dictionary of terms </returns>
        public Dictionary<string, string> CreateIndex(string path)
        {
            
            return null;
        }
    }
}
