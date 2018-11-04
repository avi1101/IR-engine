using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR_engine
{/// <summary>
/// this is the Paser class, this class cuts the document into terms and makes them fit the required criteria
/// </summary>
    public class Parse
    {
        HashSet<string> stopwords = new HashSet<string>();
        /// <summary>
        /// this is the constructor for the Parser class
        /// the constructor given a path sets the list of stopwords.
        /// </summary>
        /// <param name="path">the path of the stop words list</param>
        Parse(string path)
        {
            string stopPath = path + "\\stop_words";
            string[] stops = File.ReadAllText(stopPath).Split('\n');
            foreach (string word in stops) {
                string stpword = word.Trim();
                stopwords.Add(stpword);
            }
        }

        public void Text2list(document document)
        {
           string tmp_txt = document.getdoc();
           string[] text = tmp_txt.Split(' ');
           List<string> text2 = text.ToList();
           parseText(text2);
        }
        public void parseText(List<string> words)
        {
            foreach (string word in words)
            {
                if(word==null|| word==""||word==" ")
                {
                    words.Remove(word);
                }
                if (word.Contains("\n"))
                {
                    string word2 = word.TrimEnd('\n');
                    words.Add(word2);
                    words.Remove(word);
                }
                if (stopwords.Contains(word))
                {
                    words.Remove(word);
                }
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
