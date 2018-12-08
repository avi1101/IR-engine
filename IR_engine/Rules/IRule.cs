using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{
    interface IRule
    {
        bool CheckRule(string[] words, int idx);
        string CreatePhrase(string[] words, int idx, out int j);
    }
}
