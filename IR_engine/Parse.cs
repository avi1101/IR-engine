﻿
/*
 *                              _                             _           _          _                                                                    
 *                             | |                           | |         | |        | |                                                                   
 *     __      __   ___      __| |   ___      _ __     ___   | |_      __| |   ___  | |__    _   _    __ _                                                
 *     \ \ /\ / /  / _ \    / _` |  / _ \    | '_ \   / _ \  | __|    / _` |  / _ \ | '_ \  | | | |  / _` |                                               
 *      \ V  V /  |  __/   | (_| | | (_) |   | | | | | (_) | | |_    | (_| | |  __/ | |_) | | |_| | | (_| |                                               
 *       \_/\_/    \___|    \__,_|  \___/    |_| |_|  \___/   \__|    \__,_|  \___| |_.__/   \__,_|  \__, |                                               
 *                                                                                                    __/ |                                               
 *                                                                                                   |___/                                                
 *                                _                                     _       _     _                                   _                               
 *                               | |                                   | |     | |   | |                                 | |                              
 *     __      __   ___     ___  | |_    __ _   _ __    ___      __ _  | |_    | |_  | |__     ___      ___    ___     __| |   ___                        
 *     \ \ /\ / /  / _ \   / __| | __|  / _` | | '__|  / _ \    / _` | | __|   | __| | '_ \   / _ \    / __|  / _ \   / _` |  / _ \                       
 *      \ V  V /  |  __/   \__ \ | |_  | (_| | | |    |  __/   | (_| | | |_    | |_  | | | | |  __/   | (__  | (_) | | (_| | |  __/                       
 *       \_/\_/    \___|   |___/  \__|  \__,_| |_|     \___|    \__,_|  \__|    \__| |_| |_|  \___|    \___|  \___/   \__,_|  \___|                       
 *                                                                                                                                                        
 *                                                                                                                                                        
 *                      _     _   _     _     _                                   _                                    __                                 
 *                     | |   (_) | |   | |   | |                                 | |                                  / _|                                
 *      _   _   _ __   | |_   _  | |   | |_  | |__     ___      ___    ___     __| |   ___      ___    ___    _ __   | |_    ___   ___   ___    ___   ___ 
 *     | | | | | '_ \  | __| | | | |   | __| | '_ \   / _ \    / __|  / _ \   / _` |  / _ \    / __|  / _ \  | '_ \  |  _|  / _ \ / __| / __|  / _ \ / __|
 *     | |_| | | | | | | |_  | | | |   | |_  | | | | |  __/   | (__  | (_) | | (_| | |  __/   | (__  | (_) | | | | | | |   |  __/ \__ \ \__ \ |  __/ \__ \
 *      \__,_| |_| |_|  \__| |_| |_|    \__| |_| |_|  \___|    \___|  \___/   \__,_|  \___|    \___|  \___/  |_| |_| |_|    \___| |___/ |___/  \___| |___/
 *                                                                                                                                                        
 *                                                                                                                                                        
WWWWWWWWWWWWWWWWWWWWWWWWWNWNNWWNX0OkxxkkOO0KKKKK000KXNNNNNNWWWNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWWWWWWWWNNNXOxl;'..    ............,oOXNNNWWWNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNNNNNNNNWNOl,.                       .lkKNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNNWWNWXk:.                           .oOKNNWNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWNWNNKl.                              .lOKNNNWNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWWNNNd.                                .ck0XNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNWNWX:                                  .cxOKXNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNNWWO'                                  .'cdOKXNWWWWWNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWNWNd.                                   .,cdOKXNNWWWNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWNWNl                                     .,cdkKNWWNNWWNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWWNWXc                                      .,cdkKNNNNNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW 
WWWWWWWWWWWWWWWNWWWK;                                      ..;ldOXNNNNWWWWWWWWWWWNNWWWNNWNNWWWWWWWWW
WWWWWWWWWWWWWWWNWWWO'                                       ..:lx0NNNNNNWWWWWWWWWWWWNNNWNNNNWWWWWWWW
WWWWWWWWWWWWNNNNNNWk.                                        .':oOXNWNNWWWWWWWWWNNNNNNNNNNNNWWWWWWWW
WWWWWWWWWWWWWNNNNNNx.                                     ..',:ldOKNNWNNWWWWWWWWWNNNNXKKXNNNWWWWWWWW
NNNNWNX0Okxolc:::::'                                      .':oxkk0KKNNNNNNWNNNWWNNNKkdkKNNNWWWWWWWWW
NNKko:,..                     .......             ...',:ccllodxkkOOOKXXNNNNNNXK0xoccd0NNNWWWWWWWWWWW
Ol'.                             .............',:loodxkkkkkkxxxddddddddddolc:;'.':xKNNNNWWWWWWWWWWWW
.                                         .....'''''''''''''.......  .     .,:okKNNNNWWWNWWWWWWWWWWW
                              .....................'''''''.........  ..,:lx0XNWWNNNNNWWWWWWWWWWWWWWW
                             ....''''''..........''',,,,,'.......'',lk0XNWWWWWWWWWWWWWWWWWWWWWWWWWWW
                             ..',,,;;;;;,,'..''',;;;;;;;;,....'',;o0NWWNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
                             .',;;;::::;;;;;:::;;;;;;;;;;;;;::clccdKNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWWW
o,.                ... ...   .';::::::::ccllllc::;;;;;;;;:cc:cclookXNNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW
NXOd:..           ..''..''....,::::ccccccclllllcccc:::;;::loollodd0NWNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW
NWWNNKko:'..       .:c;''''...,::cccccclllllllllccc:::;;::colllodx0NNWWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWNNWWWNK0kdl:;'.  .::,'','.',;::ccccccllllllllc:::;;;;::cloocloxKNNWWNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWNWWWNNNNNWNNNKo.  '::;,,'.'',;:ccccccclllllllc::::::cllllooccldKNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNNO'   .;:c:;'''',;::::cccclllllcc:;;:;;;;;::::;:cxXNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNNK;    .';c:,'''',;::ccccccllcc::;;;,,,,'''''',;ckNNNWNNWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNWNd.     .,:,'.''',;:::ccllc:;,,,,,,,,,,..',,',cxKNNNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNNNKc.    .';,....',,,;::cc:;,'''',,'',,,'',;;::lkKNNNNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNWWNKc.   .';,...'',,,,;:::;,',,;;;;;;;;,,;:col::dKWNNNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNWWNXx:...,:;'...'',,,,;;;,'',:ccccccccc:cldkklckXWWNNWNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNNWNNNXKOdc:::;'..''''',,,'',;:cccccllc::::coddkKNNNWNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNWWWNNNNN0o:::cc:;'.......''''',;,,,,,,''''',:oOKNNNNNNWWNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNNWNNNNx;:;;ccccc:;'......'''''''''''''',,,:dOKKXNNNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWWNWWNNXd..lc,,;:cccc:,.......',,,,,,,,,;,,;:cdOkdkXNNNWNNWWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWWWNWNNWKc. .cd:'.,;:::::;'.......'',,,,''''',,;cllclkXNNNNNNWWWWWWWWWWWWWWWWWWWWWWWWWWW
WWWWWWWWWWWWWNNNNWWKc.   ;xdc'.',;;;;::;,'............''.''...,:clkKNNNNNNNNWWWWNNWWWNNWWWNWWNNWWWWW
WWWWWWWWWWNWWNNNX0d,     ,dxdl;.'',;;;;:;;;,,,,,''''';c:'.....';:cokxOXXXXXXXXXXNNNNNNNWWNNWWWNWWWWW
WWWWWWWWNNNNNXkc,.       .lddxdc,'',,;;;;;;;;;;;;;;;;;;;,'....';:cokod0KXKK0OO0KXXXXXXNNNNNNNNWWNWWW
WWWWWWWNNNNXk:.           'clldxl::;,;;:::;;;;;;;,,,,,,,'.....';ccoxo:lkKKKOkkkOKXXXXKKKKKXNNNNNNWWW
WWWNNNWWXOd;.              .';cl':kxoc;;:::;;;;;,,,,,,,''.'...;clool,..;ldO0kocoOKKKXK0xoloOKXKXNNNW
NWNNNX0d:.                  ..':;;dxdxoc;::;;;;;,,,,,,,''''..,l:;lolc;....:k0OdcdOkOKXXKOl'.lkxxKXNN
NWN0d:..                  .....':,.;odxdc;:;;,,;,;;;;;,,,''..lo,:OOxkO:....,;lxdx0d;:x0XNXOc.,lldKX0
Oo:'..                     .,,'',;,':odxdl:;:,,;;;;;;;,,,'.'oOocx0K0Okc..;:,..,;lxxc,,cloxOOd,'cok0x
.                          .;;::;cll:codxxxdl:;;;;;;;;,,'.;x0OkO00KKOk:..:dd:...',clo:.  ...''..cxOl
                           .;::llllllllloodxxdl:;;;,,,,,.'oKKKKXK000Ox:..':d0x:..':cdxl'        .:Od
                            .;cccc:;:clloooooodolc:;,,,'.;ONXKKXKOOOkx:.   'oO0ko,.':;'c;.        ;x
                 .......     .,c::c:::lllodddddddddoc,'..lXNXXKKK0Okxdl'    .:xKXOddc. .'.        .l
    .'..............           'ccccl:;loooodxxkxxxxxo;..dNNNXXXX0Okxol;.     .cOKNXd.             ,
        .....     ..            'clclo:;lxxdddxxkkkOOkx:'oNNNXXNKOkkxdoc'.      'ck0Ol.      ...    
                   ......        'lollo::lxkkkxdxO0KX0kxldXNNNNXOxxxxddl;.        'dkOd.  .'cdkxol,.
                    ..';.         'lolooccokOOOkxxxkkxxkdd0NNNNKxodxxdooc;.       ,ox0Xk,.,l:ck00K0d
                     ..            'ododdllokOOOOkxxdooolckNNNKOxddxxdoool,.     .::.cOXOl::;;lxOxoO
                     ..             ,oooddoldkOOOkkkxddol;oKXK0kxxdxxdooolc, .,. .c,  'dK0l::;:lcldk
                      ..            .;oodddocdO0OOkkkkxxxllO0Okkxdddxxxolllc'.'. 'c.   .:kOl:odolllc
                                     .;oddxdllk00OOkkOOkkdlxOOkxxxddxkxdollc:'   'c.    .,x0xddc:;'.
                                      .;dxddoldO00OOkOOkxdcoOOkkkxddxkxxolccc:. ..lo'  .,clokxooo,. 
                         ..            .:dxxdodO000OOOOOkdclkOkxxxxdxkkkxocclc,...,dkc..'..'cllk0d' 
                          ..            .ldxkxxk0000OOOOkd:cxOkkxxxxxkkkkdlcll:...'oOd'    .;;;d0Xk'
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IR_engine
{/// <summary>
/// this is the Paser class, this class cuts the document into terms and makes them fit the required criteria
/// </summary>
    public class Parse
    {
        private enum months { january, february, march, april, may, june, july, august, september, october, november, december };

        List<string> pre_terms;
        public static Dictionary<string, term> terms = new Dictionary<string, term>();
        HashSet<string> stopwords;
        Stemmer stem;
        bool toStem;
        string path;
        public static string DocName = "";
        public double time = 0;
        StringBuilder sb = new StringBuilder();

        /// <summary>
        /// this is the constructor for the Parser class
        /// the constructor given a path sets the list of stopwords.
        /// </summary>
        /// <param name="path">the path of the stop words list</param>
        public Parse(string path, bool tostem)
        {
            this.path = path;
            toStem = tostem;
            stopwords = new HashSet<string>();
            stem = new Stemmer();
            if (!File.Exists(path + "\\postingList.txt"))
                File.CreateText(path + "\\postingList.txt");
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
        public void Text2list(document document, int queue)
        {
            string tmp_txt = document.Doc;
            string[] text = tmp_txt.Split(' ');
            //pre_terms = text.ToList();
            DocName = document.DocID;
            parseText(text, queue);
        }
        private bool IsNumber(string str)
        {
            if (str.Length == 0) return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > '9' || str[i] < '0')
                    return false;
            }
            return true;
        }
        public void parseText(string[] words, int queue)
        {

            for (int i = 0; i < words.Length; i++)
            {
                term t;
                string phrase = "";
                int j = i;                                                                              //duplicate the current index to manipulate it without losing the index
                if (words[i] == null || words[i].Equals("")) { continue; }
                string word = words[j];
                word = Fixword(word);
                if (word == null /*|| stopwords.Contains(word.ToLower())*/) continue;
                if (word.Length > 0 && word[word.Length - 1] == '\n') word = word.TrimEnd('\n');          //remove \n from the end of a word
                if (word == "" || word == "\n" || word[0] == '<' || stopwords.Contains(word)) continue; //stip white characters, tags and stop words
                bool isUpperFirstLetter = word[0] >= 'A' && word[0] <= 'Z' ? true : false;              //checks if the word has a first capital letter
                                                                                                        //checking for rule
                if (hasChar(word, '-') && word[0] != '-')
                {
                    /* 
                     * checked for no first minus '-' to eliminate negative numbers
                     * in this case, we found a range\expression, we'll deal with this here by splitting it and save the terms
                     */
                    phrase = SetExp(i, words, out j, queue);
                }
                else if (word[0] == '\"')
                {
                    /*
                     * our own rule, in case of an expression that start and end with ""
                     * we need to save it as according to the expression rules
                     */
                    phrase = SetQuotationExp(i, words, out j, queue);
                }
                else if (containsNumbers(word))
                {
                    /* 
                     * the first word contains a number, which means it can apply one of the rules
                     * here i'll check which rule to apply
                     */

                    // checking for price existance
                    if (isPrice(words, i))
                    {
                        /*
                         * we found that word[i] is a price expression
                         * time to call the correct rule method
                         * it will return the string phrase we will use to create the term
                         */
                        phrase = Setprice(i, words, out j);
                    }
                    else if (isPercentage(words, i))
                    {
                        /*
                         * the number is a percentage format
                         * time to call the correct rule method
                         */
                        phrase = Isprecent(words, i, out j);
                    }
                    else if (isDate(words, i))
                    {
                        /*
                         * the number is in date format
                         */
                        phrase = ToDate(words[i], words[i + 1]);
                        j++;
                    }
                    else
                    {
                        /*
                         * which no latter condition is fulfilled, that means the number we found
                         * is a normal number that has to be formatted by the numbers rule
                         * we'll call the rule method here
                         */
                        phrase = NumberSet(word, i, words, out j);
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
                    if (isDate(words, i))
                    {
                        phrase = ToDate(words[i], words[i + 1]);
                        if (phrase.Equals(""))
                            phrase = toStem ? stem.stemTerm(word) : word;
                        j++;
                    }
                    else
                        phrase = toStem ? stem.stemTerm(word) : word;
                }
                t = new term(phrase);
                
                //if (terms.ContainsKey(phrase))
                //{
                //    /*
                //     * using a dictionary, we should always search a value using a key for ammortized O(1) complexity
                //     * the dictionary is implemented as a hash table with chaining
                //     * so it should give us the best resaults
                //     */
                //    t = terms[phrase]; //reference to the original term
                //}
                //else
                //{
                //    /*
                //     * this is a new tern that needs to be created
                //     */
                //    t = new term(phrase);
                //    terms.Add(t.Phrase, t);
                //}
                //t.AddToCount(DocName);
                Model.queueList[queue].Enqueue(t);
                if (!isUpperFirstLetter) t.IsUpperInCurpus = false;
                //Console.WriteLine(word);
            }

            /*
             * at the end of the doc parsing, I should end all opened doc counts for the terms
             */
            //foreach (KeyValuePair<string, term> tn in terms)
            //    tn.Value.addDocumentToPostingList();
        }

        //TODO: need to implement isDate
        private bool isDate(string[] words, int idx)
        {
            if (IsNumber(words[idx])){
                if (idx + 1 < words.Length && (words[idx + 1].Equals("january") || words[idx + 1].Equals("January") || words[idx + 1].Equals("JANUARY") || words[idx + 1].Equals("february") ||
                       words[idx + 1].Equals("February") || words[idx + 1].Equals("FEBRUARY") || words[idx + 1].Equals("march") || words[idx + 1].Equals("March") ||
                   words[idx + 1].Equals("MARCH") || words[idx + 1].Equals("april") || words[idx + 1].Equals("April") || words[idx + 1].Equals("APRIL") ||
                   words[idx + 1].Equals("may") || words[idx + 1].Equals("May") || words[idx + 1].Equals("MAY") || words[idx + 1].Equals("june") ||
                   words[idx + 1].Equals("June") || words[idx + 1].Equals("JUNE") || words[idx + 1].Equals("july") || words[idx + 1].Equals("July") ||
                   words[idx + 1].Equals("JULY") || words[idx + 1].Equals("august") || words[idx + 1].Equals("August") || words[idx + 1].Equals("AUGUST") ||
                   words[idx + 1].Equals("september") || words[idx + 1].Equals("September") || words[idx + 1].Equals("SEPTEMBER") || words[idx + 1].Equals("october") ||
                   words[idx + 1].Equals("October") || words[idx + 1].Equals("OCTOBER") || words[idx + 1].Equals("november") || words[idx + 1].Equals("November") ||
                   words[idx + 1].Equals("NOVEMBER") || words[idx + 1].Equals("december") || words[idx + 1].Equals("December") || words[idx + 1].Equals("DECEMBER")))
                    return true;
            }
            else
            {
                if (((idx + 1 < words.Length) && (IsNumber(words[idx + 1]))) && ((words[idx].Equals("january") || words[idx].Equals("January") || words[idx].Equals("JANUARY") || words[idx].Equals("february") ||
                        words[idx].Equals("February") || words[idx].Equals("FEBRUARY") || words[idx].Equals("march") || words[idx].Equals("March") ||
                    words[idx].Equals("MARCH") || words[idx].Equals("april") || words[idx].Equals("April") || words[idx].Equals("APRIL") ||
                    words[idx].Equals("may") || words[idx].Equals("May") || words[idx].Equals("MAY") || words[idx].Equals("june") ||
                    words[idx].Equals("June") || words[idx].Equals("JUNE") || words[idx].Equals("july") || words[idx].Equals("July") ||
                    words[idx].Equals("JULY") || words[idx].Equals("august") || words[idx].Equals("August") || words[idx].Equals("AUGUST") ||
                    words[idx].Equals("september") || words[idx].Equals("September") || words[idx].Equals("SEPTEMBER") || words[idx].Equals("october") ||
                    words[idx].Equals("October") || words[idx].Equals("OCTOBER") || words[idx].Equals("november") || words[idx].Equals("November") ||
                    words[idx].Equals("NOVEMBER") || words[idx].Equals("december") || words[idx].Equals("December") || words[idx].Equals("DECEMBER"))))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// checks if the enum contains a month equal to the given date is any possible occurance
        /// </summary>
        /// <param name="date">the string that holds the month</param>
        /// <returns>true is contains, false otherwise</returns>
        private bool EnumContains(string date)
        {
            date = date.ToLower();
            foreach (months m in Enum.GetValues(typeof(months)))
            {
                string m2 = m.ToString();
                string mon = m2.Substring(0, 3);
                //checks all possible combinations
                if (date.Equals(m2) || date.Equals(mon))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// this method checks if a given word in the words list is a start of a percent format
        /// </summary>
        /// <param name="words">the list of words in working on</param>
        /// <param name="idx">the index of the word in the list</param>
        /// <returns></returns>
        private bool isPercentage(string[] words, int idx)
        {
            if (words[idx][words[idx].Length - 1] == '%') return true;
            if (idx + 1 < words.Length && (words[idx + 1].Equals("percent") || words[idx + 1].Equals("Percent") ||
                words[idx + 1].Equals("percent") || words[idx + 1].Equals("PERCENT") || words.Equals("percentage") || words.Equals("percentage")
                || words.Equals("Percentage") || words.Equals("PERCENTAGE")))
                return true;
            return false;
        }

        /// <summary>
        /// this method checks if a given word in the words list is a start of a price format
        /// </summary>
        /// <param name="words">the list of words in working on</param>
        /// <param name="idx">the index of the word in the list</param>
        /// <returns></returns>
        private bool isPrice(string[] words, int idx)
        {
            if (words[idx][0] == '$') return true;
            if (idx + 2 < words.Length)
                if ((words[idx + 2].Equals("Dollars") || words[idx + 2].Equals("DOLLARS") || words[idx + 2].Equals("dollars")) &&
                   (words[idx + 1].Equals("M") || words[idx + 1].Equals("m") || words[idx + 1].Equals("Million") || words[idx + 1].Equals("MILLION") ||
                    words[idx + 1].Equals("million") || (words[idx + 1].Equals("BN")) || words[idx + 1].Equals("bn") || words[idx + 1].Equals("Billion") || words[idx + 1].Equals("BILLION") ||
                    words[idx + 1].Equals("billion") || words[idx + 1].Equals("Trillion") || words[idx + 1].Equals("TRILLION") ||
                    words[idx + 1].Equals("trillion")
                    )) return true;
            if (idx + 1 < words.Length)
                if (words[idx + 1].Equals("Dollars") || words[idx + 1].Equals("DOLLARS") || words[idx + 1].Equals("dollars"))
                    return true;
            return false;
        }
        private bool containsNumbers(string s)
        {
            //for (int i = 0; i < s.Length; i++)
            //    if (s[i] <= '9' && s[i] >= '0') return true;
            //return false;
            for (int i = 0; i < s.Length; i++)
                if ((s[i] > '9' || s[i] < '0') && s[i] != '$' && s[i] != '%' && s[i] != '/' && s[i] != '.' && s[i] != '-') return false;
            return true;
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
        bool IsRegNumber(string[] words, int idx)
        {
            for (int i = 0; i < words[idx].Length; i++)
            {
                if ((!(words[idx][i] >= '0' && words[idx][i] <= '9') && words[idx][i] != ',' && words[idx][i] != '.' && words[idx][i] != '\\' && words[idx][i] != '/') || words[idx] == "")
                    return false;
            }
            if (words[idx + 1] == "$" || words[idx + 1] == "%" || words[idx + 1] == "percent" || words[idx + 1] == "percentage" || words[idx + 1] == "Dollars") { return false; }
            if (words[idx + 1] == "Thousand" || words[idx + 1] == "thousand" || words[idx + 1] == "Million" || words[idx + 1] == "million" || words[idx + 1] == "Billion" || words[idx + 1] == "Trillion" || words[idx + 1] == "billion" || words[idx + 1] == "trillion")
            {
                if (words[idx + 2] == "$" || words[idx + 2] == "%" || words[idx + 2] == "percent" || words[idx + 2] == "percentage" || words[idx + 2] == "Dollars") { return false; }
            }
            return true;
        }

        bool IsComNum(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (!(input[i] >= '0' && input[i] <= '9') && input[i] != '.' && input[i] != '/')
                    return false;
            }
            return true;
        }
        string Isprecent(string[] words, int idx, out int j)
        {
            if (IsComNum(words[idx]) && IsComNum(words[idx + 1]) && (words[idx + 2] == "%" || words[idx + 2] == "percent"
                || words[idx + 2] == "percentage" || words[idx + 2] == "percent" || words[idx + 2] == "percentage"))
            { j = idx + 2; return words[idx] + " " + words[idx + 1] + "%"; }

            else { j = idx + 1; return words[idx] + "%"; }
        }
        /// <summary>
        /// takes a existing term with numeric valueand edited it 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="idx"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        string NumberSet(string input, int idx, string[] words, out int j)
        {
            int option = 0;
            var charsToRemove = new string[] { "," };
            foreach (var c in charsToRemove)
            {
                input = input.Replace(c, string.Empty);
            }
            if (idx + 1 == words.Length) { option = 0; }
            else if (words[idx + 1] == "Thousand" || words[idx + 1] == "thousand") { option = 1; }
            else if (words[idx + 1] == "Million" || words[idx + 1] == "million") { option = 2; }
            else if (words[idx + 1] == "Billion" || words[idx + 1] == "Trillion" || words[idx + 1] == "billion" || words[idx + 1] == "trillion") { option = 3; }
            double dbl;
            if (double.TryParse(input, out dbl))
            {
                if (option == 1) { dbl = dbl * 1000; }
                if (option == 2) { dbl = dbl * 1000000; }
                if (option == 3) { dbl = dbl * 1000000000; }
                if (dbl >= 1000 && dbl < 1000000) { dbl = dbl / 1000 + (dbl % 1000) * (1 / 1000); j = idx + 1; return (dbl.ToString() + "K"); }
                else if (dbl >= 1000000 && dbl < 1000000000) { dbl = dbl / 1000000 + (dbl % 1000000) * (1 / 1000000); j = idx + 1; return (dbl.ToString() + "M"); }
                else if (dbl >= 1000000000) { dbl = dbl / 1000000000 + (dbl % 1000000000) * (1 / 1000000000); j = idx + 1; return (dbl.ToString() + "B"); }
                else { j = idx; return (dbl.ToString()); }
            }
            int nt;
            if (int.TryParse(input, out nt))
            {
                if (option == 1) { nt = nt * 1000; }
                if (option == 2) { nt = nt * 1000000; }
                if (option == 3) { nt = nt * 1000000000; }
                if (nt >= 1000 && nt < 1000000) { nt = nt / 1000 + (nt % 1000) * (1 / 1000); j = idx + 1; return (nt.ToString() + "K"); }
                else if (nt >= 1000000 && nt < 1000000000) { nt = nt / 1000000 + (nt % 1000000) * (1 / 1000000); j = idx + 1; return (nt.ToString() + "M"); }
                else if (nt >= 1000000000) { nt = nt / 1000000000 + (nt % 1000000000) * (1 / 1000000000); j = idx + 1; return (nt.ToString() + "B"); }
                else { j = idx; return (nt.ToString()); }
            }
            long lng;
            if (long.TryParse(input, out lng))
            {
                if (option == 1) { lng = lng * 1000; }
                if (option == 2) { lng = lng * 1000000; }
                if (option == 3) { lng = lng * 1000000000; }
                if (lng >= 1000 && lng < 1000000) { lng = lng / 1000 + (lng % 1000) * (1 / 1000); j = idx + 1; return (lng.ToString() + "K"); }
                else if (lng >= 1000000 && lng < 1000000000) { lng = lng / 1000000 + (lng % 1000000) * (1 / 1000000); j = idx + 1; return (lng.ToString() + "M"); }
                else if (lng >= 1000000000) { lng = lng / 1000000000 + (lng % 1000000000) * (1 / 1000000000); j = idx + 1; return (lng.ToString() + "B"); }
                else { j = idx; return (lng.ToString()); }
            }
            decimal dec;
            if (decimal.TryParse(input, out dec))
            {
                if (option == 1) { dec = dec * 1000; }
                if (option == 2) { dec = dec * 1000000; }
                if (option == 3) { dec = dec * 1000000000; }
                if (dec >= 1000 && dec < 1000000) { dec = dec / 1000 + (dec % 1000) * (1 / 1000); j = idx + 1; return (dec.ToString() + "K"); }
                else if (lng >= 1000000 && lng < 1000000000) { dec = dec / 1000000 + (dec % 1000000) * (1 / 1000000); j = idx + 1; return (dec.ToString() + "M"); }
                else if (dec >= 1000000000) { dec = dec / 1000000000 + (dec % 1000000000) * (1 / 1000000000); j = idx + 1; return (dec.ToString() + "B"); }
                else { j = idx; return (dec.ToString()); }
            }
            else
            {
                if (option == 1) { j = idx + 1; return input + "K"; }
                if (option == 2) { j = idx + 1; return input + "M"; }
                if (option == 3) { j = idx + 1; return input + "B"; }
                else { j = idx; return input; }
            }

        }

        /// <summary>
        /// this method gets 2 strings that contains a date and returns a single string with the formatted date
        /// </summary>
        /// <param name="firstTerm">first token of the date</param>
        /// <param name="secondTerm">second token of the date</param>
        /// <returns></returns>
        string ToDate(string firstTerm, string secondTerm)
        {// TODO: change the method to support beckward term checking
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
                if (!IsNumber(secondTerm)) return "";                           //some month shortcuts can be a word like 'may'. this will tell us it is it
                month = firstTerm;
                number = secondTerm;
            }
            double value = FormatNumber(number);
            // int value = int.Parse(number);                                      //get the numeric value of the year/day
            month = month.ToLower();                                            //easier to only check lower case strings
            foreach (months m in Enum.GetValues(typeof(months)))                //iterate to find out which month it is
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
        string SetLetterType(int idx, string[] words) { return null; }
        string Setprice(int idx, string[] words, out int j)
        {
            string val = "";
            if (words[idx][0] == '$' && words[idx].Length == 1) { j = idx + 1; return "$"; }
            if (words[idx][0] == '$' && IsComNum(words[idx].Remove(0, 1).Replace(",", "")))
            {
                string numOnly = words[idx].Remove(0, 1);
                if (hasChar(numOnly, '.'))
                {
                    /*
                     * the word looks like $6.5 Million or $6.5
                     */
                    if (!Char.IsDigit(numOnly[numOnly.Length - 1])) { numOnly = numOnly.Remove(numOnly.Length - 1); }
                    bool ans = true;
                    while (ans)
                    {
                        if (Char.IsDigit(numOnly[numOnly.Length - 1])) { ans = false; break; }
                        numOnly = numOnly.Remove(numOnly.Length - 1);
                    }
                    double amount = 0;
                    try
                    {
                        amount = FormatNumber(numOnly);

                    }
                    catch (Exception e)
                    {
                        j = idx;
                        return words[idx];
                    }
                    if (amount > 1000000) { amount = amount / 1000000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx; }
                    else
                    {
                        if (idx + 1 == words.Length && words[idx][0] == '$')
                        {
                            j = idx;
                            val = words[idx].Remove(0, 1);
                            return val + " Dollars";
                        }
                        string lvl = words[idx + 1].ToUpper();
                        if (lvl == "M" || lvl == "MILLION") { string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (lvl == "BILLION" || lvl == "BN") { amount = amount * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (lvl == "TRILLION") { amount = amount * 1000 * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else { val = amount.ToString("#,##0.##"); j = idx; }
                    }
                    val = val + " Dollars";
                    return val;
                }

                else
                {
                    /*
                     * the word looks like $78 Billion or $78
                     */

                    double amount = FormatNumber(numOnly);
                    if (amount > 1000000) { double amount2 = amount / 1000000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx; }
                    else
                    {
                        if (idx + 1 == words.Length && words[idx][0] == '$')
                        {
                            j = idx;
                            val = words[idx].Remove(0, 1);
                            return val + " Dollars";
                        }
                        string lvl = words[idx + 1].ToUpper();
                        if (lvl == "M" || lvl == "MILLION") { string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (lvl == "BILLION" || lvl == "BN") { amount = amount * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (lvl == "TRILLION") { amount = amount * 1000 * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else { val = amount.ToString("#,##0.##"); j = idx; }
                    }
                    val = val + " Dollars";

                    return val;
                }
            }
            else
            {
                /*
                 * the word looks like 45 4/5 dollars
                 */
                if (idx + 1 == words.Length) { }
                if (IsComNum(words[idx + 1]) && hasChar(words[idx + 1], '/'))
                {
                    val = words[idx] + " " + words[idx + 1] + " Dollars";
                    j = idx + 2;
                    return val;
                }
                /*
                 * the word looks like 45 Dollars or 45 M dollars or 45 M U.S. dollars
                 */
                else
                {
                    string lvl = words[idx + 1].ToUpper();
                    if (lvl == "M" || lvl == "MILLION")
                    {
                        val = words[idx] + " M " + "Dollars";
                        if (words[idx + 2] == "US" || words[idx + 2] == "U.S" || words[idx + 2] == "U.S.")
                        { j = idx + 3; }
                        j = idx + 2;
                        return val;
                    }
                    else if (lvl == "BILLION" || lvl == "BN")
                    {
                        if (hasChar(words[idx],'.'))
                        {

                            double value = FormatNumber(words[idx]);
                            value = value * 1000;
                            val = value + " M " + "Dollars";
                            if (words[idx + 2] == "US" || words[idx + 2] == "U.S" || words[idx + 2] == "U.S.")
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;
                        }
                        else
                        {

                            double value = FormatNumber(words[idx]);
                            value = value * 1000;
                            val = value + " M " + "Dollars";
                            if (words[idx + 2] == "US" || words[idx + 2] == "U.S" || words[idx + 2] == "U.S.")
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;

                        }
                    }
                    else if (lvl == "TRILLION" || lvl == "BN")
                    {
                        if (hasChar(words[idx],'.'))
                        {
                            double value = FormatNumber(words[idx]);
                            value = value * 1000 * 1000;
                            val = value + " M " + "Dollars";
                            if (words[idx + 2] == "US" || words[idx + 2] == "U.S" || words[idx + 2] == "U.S.")
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;
                        }
                        else
                        {
                            double value = FormatNumber(words[idx]);
                            value = value * 1000 * 1000;
                            val = value + " M " + "Dollars";
                            if (words[idx + 2] == "US" || words[idx + 2] == "U.S" || words[idx + 2] == "U.S.")
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;

                        }
                    }
                    else { val = words[idx] + " Dollars"; j = idx + 1; return val; }
                }

            }
        }
        string SetExp(int idx, string[] words, out int j, int queue)
        {
            string word = words[idx];
            string[] splittedExpression = word.Split('-');
            string exp = "";
            int part = 0;
            List<string> expression = new List<string>();
            //if its a range then we need to seperate it to both ends and format it with correct rule
            if (splittedExpression.Length == 2 && IsNumber(splittedExpression[0]) && IsNumber(splittedExpression[1]))
            {                                                                                   //for example 6-7 (expression)
                term right, left;
                if (idx + 1 < words.Length && EnumContains(words[idx + 1]))
                {
                    left = new term(splittedExpression[0] + " " + words[idx + 1].ToLower());       //term phrase = "6 may"
                    right = new term(splittedExpression[1] + " " + words[idx + 1].ToLower());   //term phrase = "7 may"
                }
                else if (isPercentage(words, idx))
                {
                    left = new term(splittedExpression[0] + "%");                               //term phrase = "6%"
                    right = new term(splittedExpression[1] + "%");                              //term phrase = "7%"
                }
                else if (isPrice(words, idx))
                {
                    words[idx] = splittedExpression[0];
                    left = new term(Setprice(idx, words, out part));                            //term phrase = "6 million dollars"
                    words[idx] = splittedExpression[1];
                    right = new term(Setprice(idx, words, out part));                           //term phrase = "7 million dollars"
                }
                else
                {
                    left = new term(splittedExpression[0]);                                     //normal range
                    right = new term(splittedExpression[1]);
                }
                Model.queueList[queue].Enqueue(left);
                Model.queueList[queue].Enqueue(right);
                j = part;
                return word;
            }
            for (part = 0; part < splittedExpression.Length; part++)                    //when we meet an expression we need to format it is an expression
            {
                exp = splittedExpression[part];                                         //taking the i word of the expression
                if (exp.Equals("")) continue;
                if (toStem)                                                             //stem if needed
                    exp = stem.stemTerm(exp);
                term t = new term(exp);
                Model.queueList[queue].Enqueue(t);                                      //adding a new term or updating an existing term
            }
            j = part;                                                                   //returns the index
            return word;                                                                //returns the whole expression
        }
        string SetQuotationExp(int idx, string[] words, out int j, int queue)
        {
            // TODO: remove this line after debug
            //Console.WriteLine("Pasring an expression at doc: " + DocName + " starting at: " + words[idx]);
            if (words[idx].Equals("\"Weekly"))
                j = idx;
            string exp = "";
            bool expEnd = false;                                                        //will check if the end word has been reached 
            List<string> newWords = new List<string>();
            int i = idx;
            int k = 0;
            for (; i < words.Length && !expEnd; i++)
            {
                string word = words[idx];
                if (word[word.Length - 1] == '\"') expEnd = true;
                word = Fixword(word);
                if (word[0] == '\"' || word[word.Length - 1] == '\"') word = word.Trim('\"');
                newWords.Add(word);
            }
            parseText(newWords.ToArray(), queue);                                       //will parse the new list in case for double rule
            j = i - 1;
            return exp;

        }
        string Fixword(string word)
        {
            word = word.Replace(":", "");
            bool done = false;
            while (!done)
            {
                done = true;
                if (word != "" && word != "\n" && word[0] != '<')
                {

                    if (word[word.Length - 1] == '.' || word[word.Length - 1] == ',' || word[word.Length - 1] == '\n' ||
                        word[word.Length - 1] == ')' || word[word.Length - 1] == '}' ||
                        word[word.Length - 1] == '>' || word[word.Length - 1] == '-' || word[word.Length - 1] == ']' || word[word.Length - 1] == ';')
                    {
                        done = false;
                        word = word.Remove(word.Length - 1);
                    }

                    if (word != "" && word != "\n" && word[0] != '<')
                    {
                        //removes non-relative end characters from words
                        if (word[0] == '.' || word[0] == ',' || word[0] == '\n' || word[0] == '(' || word[0] == '{' ||
                           word[0] == '<' || word[0] == '[' || word[0] == '?')
                        {
                            done = false;
                            word = word.Remove(0, 1);
                        }
                    }
                }
            }
            if (word != "")
            {
                return word;
            }

            return null;
        }

        private void AddTerm(term t)
        {
            if (terms.ContainsKey(t.Phrase))
                t = terms[t.Phrase];
            else
                terms.Add(t.Phrase, t);
            bool isUpperFirstLetter = t.Phrase[0] >= 'A' && t.Phrase[0] <= 'Z' ? true : false;
            t.AddToCount(DocName);
            if (!isUpperFirstLetter) t.IsUpperInCurpus = false;
        }

        /// <summary>
        /// this method gets a string that represents a number and format it into double representation 
        /// of the same string
        /// </summary>
        /// <param name="num">a string that contains the number</param>
        /// <returns>a double number formatted out of the string</returns>
        private double FormatNumber(string num)
        {
            Double interval = 1;
            Double number = 0;
            Boolean isNumber = false;
            int floatingPoint = num.IndexOf('.');
            for (int i = num.Length - 1; i > floatingPoint; i--)
            {
                if (num[i] > '9' || num[i] < '0') num = num.Remove(i, 1);
            }
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] <= '9' && num[i] >= '0')
                {
                    number += Char.GetNumericValue(num[i]) * interval;
                    interval *= 10;
                    isNumber = true;
                }
            }
            if (!isNumber)
                throw new NotSupportedException();
            if (floatingPoint >= 0)
            {
                int len = num.Length - floatingPoint - 1;
                number *= Math.Pow(10, -1 * len);
            }
            return number;
        }

        bool hasChar(string word, char del)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == del || word[word.Length - i - 1] == del)
                    return true;
            }
            return false;
        }
    }
}
