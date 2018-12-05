using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    public class indexTerm
    {
        public int icf;
        public short idf;
        public readonly string phrase;
        public readonly term.Type type;

        public indexTerm(string phrase, term.Type type)
        {
            this.phrase = phrase;
            this.type = type;
        }

        public override string ToString()
        {
            return phrase + '\t' + type.ToString();
        }
    }
}
