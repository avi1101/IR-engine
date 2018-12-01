using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    class DocumentInfo
    {
        public double maxTF;
        public double distinctTerms;
        public string location;

        public DocumentInfo()
        {
            maxTF = 0;
            distinctTerms = 0;
            location = "";
        }

        public DocumentInfo(double maxTF, double distinctTerms, string location)
        {
            this.maxTF = maxTF;
            this.location = location;
            this.distinctTerms = distinctTerms;
        }
    }
}
