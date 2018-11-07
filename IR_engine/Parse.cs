﻿using System;
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
        private enum months { january, february, march, april, may, june, july, august, september, october, november, december };

        List<string> pre_terms;
        HashSet<string> terms;
        HashSet<string> stopwords;
        Stemmer stem;
        bool toStem;

        /// <summary>
        /// this is the constructor for the Parser class
        /// the constructor given a path sets the list of stopwords.
        /// </summary>
        /// <param name="path">the path of the stop words list</param>
        public Parse(string path, bool tostem)
        {
            toStem = tostem;
            stopwords = new HashSet<string>();
            terms = new HashSet<string>();
            stem = new Stemmer();
            string stopPath = path + "\\stop_words.txt";
            string[] stops = File.ReadAllText(stopPath).Split('\n');
            foreach (string word in stops)
            {
                string stpword = word.Trim();
                stopwords.Add(stpword);
            }
        }
        /// <summary>
        /// gets the text part of the document, turns it into a list of words and sends to parser
        /// </summary>
        /// <param name="document"> the document edited</param>
        public void Text2list(document document)
        {
            string tmp_txt = document.Doc;
            string[] text = tmp_txt.Split(' ');
            pre_terms = text.ToList();
            parseText(pre_terms, toStem);
        }
        private bool IsNumber(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > '9' || str[i] < '0')
                    return false;
            }
            return true;
        }
        public void parseText(List<string> words, bool ToStem)
        {
            for (int i = 0; i < words.Count - 4/*still not sure about that*/; i++)
            {
                //string word = words[i];
                //if (word == null || word == "" || word == " " || word[0]=='<')
                //    continue;
                //if (word.Contains("\n"))
                //{
                //    string word2 = word.TrimEnd('\n');
                //    words.Remove(word);
                //    word = word2;
                //}
                //if (stopwords.Contains(word))
                //    continue;
                //if (IsRegNumber(word, i))
                //{
                //    if (IsRegNumber(words[i + 1], i + 1) && words[i + 1].Contains("\\"))
                //    {
                //        string word3 = NumberSet(words[i] + " " + words[i + 1], i + 1, words);
                //        terms.Add(word3);
                //        continue;
                //    }
                //    string word2 = NumberSet(word, i, words);
                //    terms.Add(word2);
                //}
                //else if (Isprecent(word, i)!=0) {
                //    int typePrecent = Isprecent(word, i);
                //    if (typePrecent == 1)
                //        terms.Add(words[i] + " " + words[i + 1]);
                //    if (typePrecent == 2)
                //        terms.Add(words[i] + " " + words[i + 1] + " " + words[i + 2]);
                //}
                //else //should add all rules before reaching here
                //{
                //    if (ToStem)
                //        word = stem.stemTerm(word);
                //}
                int j = i;                                                                              //duplicate the current index to manipulate it without losing the index
                string word = words[j];
                if (word.Length > 0 && word[word.Length] == '\n') word = word.TrimEnd('\n');            //remove \n from the end of a word
                if (word == "" || word == "\n" || word[0] == '<' || stopwords.Contains(word)) continue; //stip white characters, tags and stop words
                //checking for rule
                /*
                * each term to parse is build from up to 5 words
                * aside of a special date case, all of them starts with numbers
                * for example: 'price friction MILLION US dollars'
                * for my first step is to determind if the first is a term with '-' or any other since its special
                * than I will check if word contains a number what so ever
                */
                if(word.Contains('-') && word[0] != '-')
                {
                    /* 
                     * checked for no first minus '-' to eliminate negative numbers
                     * in this case, we found a range\expression, we'll deal with this here by splitting it and save the terms
                     */
                    string[] splittedExpression = word.Split('-');
                    for(int part = 0; part < word.Length; part++)
                    {
                        //TODO: complete last rule here
                    }
                }
                else if (containsNumbers(word))
                {
                    /* 
                     * the first word contains a number, which means it can apply one of the rules
                     * here i'll check which rule to apply
                     */

                    // checking for price existance
                    if(isPrice(words, i))
                    {
                        /*
                         * we found that word[i] is a price expression
                         * time to call the correct rule method
                         * it will return the string phrase we will use to create the term
                         */
                    }
                    else if (isPercentage(words, i))
                    {
                        /*
                         * the number is a percentage format
                         * time to call the correct rule method
                         */
                    }
                    else if(isDate(words, i))
                    {
                        /*
                         * the number is in date format
                         */
                    }
                    else
                    {
                        /*
                         * which no latter condition is fulfilled, that means the number we found
                         * is a normal number that has to be formatted by the numbers rule
                         * we'll call the rule method here
                         */
                    }
                }
                else
                {
                    /*
                     * it has been found that 'word' has no numbers in it what so ever
                     * so there are 3 cases for that to happen:
                     * 1- date that starts with month, like MAY 14 where word = MAY
                     * 2- its a regular word with no rule to apply
                     */
                }
            }
        }
        //TODO: need to implement isDate
        private bool isDate(List<string> words, int idx)
        {
            return false;
        }

        /// <summary>
        /// this method checks if a given word in the words list is a start of a percent format
        /// </summary>
        /// <param name="words">the list of words in working on</param>
        /// <param name="idx">the index of the word in the list</param>
        /// <returns></returns>
        private bool isPercentage(List<string> words, int idx)
        {
            int size = words[idx].Length - 1;
            if (words[idx][size] == '%') return true;
            string word = words[idx + 1].ToLower();
            if (word.Equals("percent") || word.Equals("percentage")) return true;
            return false;
        }

        /// <summary>
        /// this method checks if a given word in the words list is a start of a price format
        /// </summary>
        /// <param name="words">the list of words in working on</param>
        /// <param name="idx">the index of the word in the list</param>
        /// <returns></returns>
        private bool isPrice(List<string> words, int idx)
        {
            string word = "";

            word = words[idx + 1].ToUpper();
            if (words[idx][0] == '$' || word.Equals("DOLLARS")) return true;
            if ((word.Equals("M") || word.Equals("BN")) &&
                (words[idx + 2].Equals("DOLLARS") || words[idx + 2].Equals("dollars") || words[idx + 2].Equals("Dollars")))
                return true;
            //checking for million billion trillion after the price number
            if (word.Equals("MILLION") || word.Equals("BILLION") || word.Equals("TRILLION")) return true;
            return false;
        }

        private bool containsNumbers(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (s[i] <= '9' && s[i] >= '0') return true;
            return false;
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
        bool IsRegNumber(string input, int idx)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) && input[i] != ',' && input[i] != '.' && input[i] != '\\')
                    return false;
            }
            if (pre_terms[idx + 1] == "$" || pre_terms[idx + 1] == "%" || pre_terms[idx + 1] == "percent" || pre_terms[idx + 1] == "percentage" || pre_terms[idx + 1] == "Dollars") { return false; }
            if (pre_terms[idx + 1] == "Thousand" || pre_terms[idx + 1] == "thousand" || pre_terms[idx + 1] == "Million" || pre_terms[idx + 1] == "million" || pre_terms[idx + 1] == "Billion" || pre_terms[idx + 1] == "Trillion" || pre_terms[idx + 1] == "billion" || pre_terms[idx + 1] == "trillion")
            {
                if (pre_terms[idx + 2] == "$" || pre_terms[idx + 2] == "%" || pre_terms[idx + 2] == "percent" || pre_terms[idx + 2] == "percentage" || pre_terms[idx + 2] == "Dollars") { return false; }
            }
            return true;
        }

        bool IsComNum(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsDigit(input[i]) && input[i] != ',' && input[i] != '.' && input[i] != '\\')
                    return false;
            }
            return true;
        }
        int Isprecent(string input, int idx)
        {
            if (IsComNum(input) && (pre_terms[idx + 1] == "%" || pre_terms[idx + 1] == "percent" ||
                pre_terms[idx + 1] == "percentage" || pre_terms[idx + 1] == "percent" ||
                pre_terms[idx + 1] == "percentage")) { return 1; }
            if (IsComNum(input) && IsComNum(pre_terms[idx + 1]) &&
                (pre_terms[idx + 2] == "%" || pre_terms[idx + 2] == "percent" ||
                pre_terms[idx + 2] == "percentage" || pre_terms[idx + 2] == "percent" ||
                pre_terms[idx + 2] == "percentage")) { return 2; }
            return 0;
        }
        /// <summary>
        /// takes a existing term with numeric valueand edited it 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="idx"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        string NumberSet(string input, int idx, List<string> words)
        {
            int option = 0;
            var charsToRemove = new string[] { "," };
            foreach (var c in charsToRemove)
            {
                input = input.Replace(c, string.Empty);
            }
            if (words[idx + 1] == "Thousand" || words[idx + 1] == "thousand") { option = 1; }
            if (words[idx + 1] == "Million" || words[idx + 1] == "million") { option = 2; }
            if (words[idx + 1] == "Billion" || words[idx + 1] == "Trillion" || words[idx + 1] == "billion" || words[idx + 1] == "trillion") { option = 3; }
            double dbl;
            if (double.TryParse(input, out dbl))
            {
                if (option == 1) { dbl = dbl * 1000; }
                if (option == 2) { dbl = dbl * 1000000; }
                if (option == 3) { dbl = dbl * 1000000000; }
                if (dbl >= 1000 && dbl < 1000000) { dbl = dbl / 1000 + (dbl % 1000) * (1 / 1000); return (dbl.ToString() + "K"); }
                else if (dbl >= 1000000 && dbl < 1000000000) { dbl = dbl / 1000000 + (dbl % 1000000) * (1 / 1000000); return (dbl.ToString() + "M"); }
                else if (dbl >= 1000000000) { dbl = dbl / 1000000000 + (dbl % 1000000000) * (1 / 1000000000); return (dbl.ToString() + "B"); }
                else { return (dbl.ToString()); }
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
                else
                {
                    if (option == 1) { return input + "K"; }
                    if (option == 2) { return input + "M"; }
                    if (option == 3) { return input + "B"; }
                    else { return input; }
                }
            }
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
            if (IsNumber(firstTerm))                                             //if the number is the first term
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
            foreach (months m in Enum.GetValues(typeof(months)))                 //iterate to find out which month it is
            {
                string m2 = m.ToString();
                string mon = m2.Substring(0, 3);
                //checks all possible combinations
                if (month.Equals(m2) || month.Equals(mon))
                {
                    if (((int)m + 1) < 10)                                         //adds the zero before the number
                        month = "0" + ((int)m + 1) + "";
                    else
                        month = ((int)m + 1) + "";
                    break;
                }
            }
            if (number.Length == 1) number = "0" + number;
            if (value > 999)
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
            for (int i = 0; i < numberOfTests; i++)
            {
                Array values = Enum.GetValues(typeof(months));
                string randomBar = ((months)values.GetValue(r.Next(values.Length))).ToString();
                int n = r.Next(1, 50);
                int rand = r.Next(0, 3);
                if (rand == 0) randomBar = randomBar.Substring(0, 3);
                if (rand == 1) randomBar = randomBar.ToUpper();
                if (r.Next(0, 1) == 1)
                    sol += ToDate(n + "", randomBar.ToString()) + "\t" + n + " " + randomBar.ToString() + "\n";
                else
                    sol += ToDate(randomBar.ToString(), n + "") + "\t" + n + " " + randomBar.ToString() + "\n";
            }
            return sol;
        }
        string SetLetterType(int idx, List<string> words) { return null; }
        string Setprice(int idx, List<string> words) { return null; }
        string[] SetParExp(int idx, List<string> words) { return null; }
    }
}
