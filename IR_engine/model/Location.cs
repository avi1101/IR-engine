using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace IR_engine.model
{
    class Location
    {
        public string Country;
        public ConcurrentDictionary<string, HashSet<short>> locationsInDocs;
        public string population;
        public string currency;
        public string Capital;

        public Location()
        {
            Country = "";
            population = "";
            currency = "";
            Capital = "";
            locationsInDocs = new ConcurrentDictionary<string, HashSet<short>>();
        }
    }
}
