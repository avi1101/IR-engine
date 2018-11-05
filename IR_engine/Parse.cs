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
        List<string> pre_terms ;
        HashSet<string> terms = new HashSet<string>();
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
            pre_terms = new List<string>();
        }
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
            for(int i =0;i<words.Count;i++)
            {
                string word = words[i];
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
                else if (IsRegNumber(word,i))
                {
                    if (IsRegNumber(words[i+1], i + 1) && words[i+1].Contains("\\"))
                    {
                        string word3 = NumberSet(words[i] + " " + words[i + 1], i + 1, words);
                        terms.Add(word3);
                        continue;
                    }
                    string word2 = NumberSet(word,i,words);
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
        bool IsRegNumber(string input,int idx)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) || input[i]!=',' || input[i]!='.' || input[i]!='\\' )
                    return false;
            }
            if(pre_terms[idx+1]=="$" || pre_terms[idx + 1] =="%" || pre_terms[idx + 1] == "percent" || pre_terms[idx + 1] == "percentage" || pre_terms[idx + 1] == "Dollars") { return false;}
            if(pre_terms[idx+1]== "Thousand" || pre_terms[idx + 1] == "thousand" || pre_terms[idx + 1] == "Million" ||pre_terms[idx+1] == "million"||pre_terms[idx + 1] == "Billion"||pre_terms[idx + 1] == "Trillion" || pre_terms[idx + 1] == "billion" || pre_terms[idx + 1] == "trillion")
            {
                if (pre_terms[idx + 2] == "$" || pre_terms[idx + 2] == "%" || pre_terms[idx + 2] == "percent" || pre_terms[idx + 2] == "percentage" || pre_terms[idx + 2] == "Dollars") { return false; }
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
            var charsToRemove = new string[] {","};
            foreach (var c in charsToRemove)
            {
                input = input.Replace(c, string.Empty);
            }
            if (words[idx + 1] == "Thousand" || words[idx + 1] == "thousand") { option = 1; }
            if (words[idx + 1] == "Million" || words[idx + 1] == "million") { option = 2; }
            if (words[idx + 1] == "Billion" || words[idx + 1] == "Trillion" || words[idx + 1] == "billion" || words[idx + 1] == "trillion") { option = 3; }
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
                else {
                    if (option == 1) { return input + "K"; }
                    if (option == 2) { return input + "M"; }
                    if (option == 3) { return input + "B"; }
                }
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
        }
    }

