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
        private enum months {january,february,march,april,may,june,july,august,september,october,november,december};
        List<string> terms = new List<string>();
        HashSet<string> stopwords = new HashSet<string>();
        /// <summary>
        /// this is the constructor for the Parser class
        /// the constructor given a path sets the list of stopwords.
        /// </summary>
        /// <param name="path">the path of the stop words list</param>
        public Parse(string path)
        {
            string stopPath = path + "\\stop_words";
            string[] stops = File.ReadAllText(stopPath).Split('\n');
            foreach (string word in stops) {
                string stpword = word.Trim();
                stopwords.Add(stpword);
            }
        }

        public Parse() { }
        /// <summary>
        /// gets the text part of the document, turns it into a list of words and sends to parser
        /// </summary>
        /// <param name="document"> the document edited</param>
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
                if (word == null || word == "" || word == " ")
                    continue;
                else if (word.Contains("\n"))
                {
                    string word2 = word.TrimEnd('\n');
                    words.Add(word2);
                    words.Remove(word);
                }
                else if (stopwords.Contains(word))
                    continue;
                else if (IsNumber(word))
                {
                    string word2 = NumberSet(word,words.IndexOf(word),words);
                    terms.Add(word2);

                }
            }
        }
        /// <summary>
        /// checks if the word is all made of upper case letter
        /// </summary>
        /// <param name="input"> the word tested</param>
        /// <returns></returns>
        bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// checks of the term is a numeric one
        /// </summary>
        /// <param name="input">cheked term</param>
        /// <returns></returns>
        bool IsNumber(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > '9' || input[i] < '0')
                    return false;
            }
            return true;
        }
        /// <summary>
        /// takes a existing term with numeric valueand edited it 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="idx"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        string NumberSet(string input,int idx,List<string>words)
        {
            int option = 0;
            var charsToRemove = new string[] {",", "."};
            foreach (var c in charsToRemove)
            {
                input = input.Replace(c, string.Empty);
            }
            if (words[idx + 1] == "Thousand"){ option = 1; }
            if (words[idx + 1] == "Million") { option = 2; }
            if (words[idx + 1] == "Billion" || words[idx + 1] == "Trillion") { option = 3; }
            double dbl;
            if(double.TryParse(input, out dbl))
            {
                if (option == 1) { dbl = dbl * 1000; }
                if (option == 2) { dbl = dbl * 1000000; }
                if (option == 3) { dbl = dbl * 1000000000; }
                if (dbl >= 1000 && dbl < 1000000) { dbl = dbl / 1000 + (dbl % 1000) * (1 / 1000); return (dbl.ToString() + "K"); }
                else if (dbl >= 1000000 && dbl < 1000000000) { dbl = dbl / 1000000 + (dbl % 1000000) * (1 / 1000000); return (dbl.ToString() + "M"); }
                else if (dbl >= 1000000000) { dbl = dbl / 1000000000 + (dbl % 1000000000) * (1 / 1000000000); return (dbl.ToString() + "B"); }
                else {return (dbl.ToString());}
                }
            int nt;
            if (int.TryParse(input, out nt))
                {
                    if (option == 1) { nt = nt * 1000; }
                    if (option == 2) { nt = nt * 1000000; }
                    if (option == 3) { nt = nt * 1000000000; }
                    if (nt >= 1000 && nt < 1000000) { nt = nt / 1000 + (nt % 1000) * (1 / 1000); return (nt.ToString() + "K"); }
                    else if (nt >= 1000000 && nt < 1000000000) { nt = nt / 1000000 + (nt % 1000000) * (1 / 1000000); return (nt.ToString() + "M"); }
                    else if (nt >= 1000000000) { nt = nt / 1000000000 + (nt % 1000000000) * (1 / 1000000000); return (nt.ToString() + "B"); }
                    else { return (nt.ToString()); }
                }
            long lng;
            if (long.TryParse(input, out lng))
            {
                if (option == 1) { lng = lng * 1000; }
                if (option == 2) { lng = lng * 1000000; }
                if (option == 3) { lng = lng * 1000000000; }
                if (lng >= 1000 && lng < 1000000) { lng = lng / 1000 + (lng % 1000) * (1 / 1000); return (lng.ToString() + "K"); }
                else if (lng >= 1000000 && lng < 1000000000) { lng = lng / 1000000 + (lng % 1000000) * (1 / 1000000); return (lng.ToString() + "M"); }
                else if (lng >= 1000000000) { lng = lng / 1000000000 + (lng % 1000000000) * (1 / 1000000000); return (lng.ToString() + "B"); }
                else { return (lng.ToString()); }
            }
            decimal dec;
            if (decimal.TryParse(input, out dec))
            {
                if (option == 1) { dec = dec * 1000; }
                if (option == 2) { dec = dec * 1000000; }
                if (option == 3) { dec = dec * 1000000000; }
                if (dec >= 1000 && dec < 1000000) { dec = dec / 1000 + (dec % 1000) * (1 / 1000); return (dec.ToString() + "K"); }
                else if (lng >= 1000000 && lng < 1000000000) { dec = dec / 1000000 + (dec % 1000000) * (1 / 1000000); return (dec.ToString() + "M"); }
                else if (dec >= 1000000000) { dec = dec / 1000000000 + (dec % 1000000000) * (1 / 1000000000); return (dec.ToString() + "B"); }
                else { return (dec.ToString()); }
            }
            /*
            string up; string down;
            int num_up; int num_down; int num;
            if (input.Contains("\\"))
            {
                up = input.Substring(0, input.IndexOf('\\'));
                down = input.Substring(input.IndexOf('\\'));
                int.TryParse(up, out num_up);
                int.TryParse(down, out num_down);
                num = num_up / num_down;
                if (option == 1){num = num * 1000;}
                if (option == 2){num = num * 1000000;}
                if (option == 3){num = num * 1000000000;}
                */
            else { return null; }
        }

        /// <summary>
        /// this method gets 2 strings that contains a date and returns a single string with the formatted date
        /// </summary>
        /// <param name="firstTerm">first token of the date</param>
        /// <param name="secondTerm">second token of the date</param>
        /// <returns></returns>
        string ToDate(string firstTerm, string secondTerm)
        {
            string month = "";
            string number = "";
            string sol = "";
            if(IsNumber(firstTerm))                                             //if the number is the first term
            {
                month = secondTerm;
                number = firstTerm;
            }
            else                                                                //if the number is the second term
            {
                month = firstTerm;
                number = secondTerm;
            }
            int value = int.Parse(number);                                      //get the numeric value of the year/day
            month = month.ToLower();                                            //easier to only check lower case strings
            foreach(months m in Enum.GetValues(typeof(months)))                 //iterate to find out which month it is
            {
                string m2 = m.ToString();
                string mon = m2.Substring(0, 3);
                                                                                //checks all possible combinations
                if(month.Equals(m2) || month.Equals(mon))
                {
                    if(((int)m+1) < 10)                                         //adds the zero before the number
                        month = "0"+((int)m + 1) + "";
                    else
                        month = ((int)m + 1) + "";
                    break;
                }
            }
            if (number.Length == 1) number = "0" + number;
            if(value > 999)
                sol = number + "-" + month;
            else
                sol = month + "-" + number;
            return sol;
        }
        /// <summary>
        /// this is a testing method for the ToDate method
        /// </summary>
        /// <returns>the formatted string equal to the rules we were provided</returns>
        public string testToDate(int numberOfTests)
        {
            Random r = new Random();
            string sol = "";
            for(int i = 0; i < numberOfTests; i++)
            {
                Array values = Enum.GetValues(typeof(months));
                string randomBar = ((months)values.GetValue(r.Next(values.Length))).ToString();
                int n = r.Next(1, 50);
                int rand = r.Next(0, 3);
                if (rand == 0) randomBar = randomBar.Substring(0, 3);
                if (rand == 1) randomBar = randomBar.ToUpper();
                if(r.Next(0,1) == 1)
                    sol += ToDate(n+"", randomBar.ToString()) +"\t"+n+" "+randomBar.ToString()+"\n";
                else
                    sol += ToDate(randomBar.ToString(), n + "") + "\t" + n + " " + randomBar.ToString() + "\n";
            }
            return sol;
        }
    }
}
