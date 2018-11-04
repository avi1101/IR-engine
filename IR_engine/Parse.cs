using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    public class Parse
    {
       / document d;
        HashSet<string> terms = new HashSet<string>();

        public void parsedoc(document d) { this.d = d;}
        
        public void parseText()
        {
            string x = d.getdoc();
            string[] x2 = x.Split(' ');
            foreach (string word in x2)
            {
                if(IsAllUpper(word)) { }
            }

        }

        bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }

            return true;
        }

    }
}
