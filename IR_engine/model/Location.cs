using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace IR_engine
{
    public class Location
    {
        private string country;
        private ConcurrentDictionary<string, HashSet<short>> locationsInDocs;
        private string population;
        private string currency;
        private string capital;
        private string city;

        public string Country { get => country; set => country = value; }
        public ConcurrentDictionary<string, HashSet<short>> LocationsInDocs { get => locationsInDocs; set => locationsInDocs = value; }
        public string Population { get => population; set => population = value; }
        public string Currency { get => currency; set => currency = value; }
        public string Capital { get => capital; set => capital = value; }
        public string City { get => city; set => city = value; }

        public Location()
        {
            Country = "";
            population = "";
            currency = "";
            Capital = "";
            city = "";
            locationsInDocs = new ConcurrentDictionary<string, HashSet<short>>();
        }

        public Location(string city, string Country, string populationTemp,string currency,string Capital)
        {
            this.city = city;
            string popstr = populationTemp;
            double pop = double.Parse(populationTemp);
            if(pop>=1000 && pop< 1000000) { pop = pop / 1000; popstr = pop + "K"; }
            else if (pop >= 1000000 && pop< 1000000000){pop = pop / 1000000; popstr=pop+"M";}
            else if (pop>= 1000000000) { pop = pop / 1000000000; popstr = pop + "B"; }
            else { popstr = pop + ""; }
            this.Country = Country;
            this.population = popstr;
            this.currency = currency;
            this.Capital = Capital;
            locationsInDocs = new ConcurrentDictionary<string, HashSet<short>>();
        }

    }
}
