﻿/*
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
        //private enum months { january, february, march, april, may, june, july, august, september, october, november, december };

        List<string> pre_terms;
         public Dictionary<string, term> terms = new Dictionary<string, term>();
        static public HashSet<string> dollars = new HashSet<string>() { "Dollars", "DOLLARS", "dollars" };
        static public HashSet<string> million = new HashSet<string>() { "M", "m", "Million", "MILLION", "million" };
        static public HashSet<string> thousends = new HashSet<string>() { "Thousand", "thousand", "THOUSAND" };
        static public HashSet<string> allAmounts = new HashSet<string>() { "M", "m", "Million", "MILLION", "million", "Thousand", "thousand", "THOUSAND", "trillion", "Trillion", "TRILLION", "BN", "bn", "Billion", "billion", "BILLION" };
        static public HashSet<string> US = new HashSet<string>() { "US", "U.S" };
        static public HashSet<string> billion = new HashSet<string>() { "BN", "bn", "Billion", "billion", "BILLION" };
        static public HashSet<string> trillion = new HashSet<string>() { "trillion", "Trillion", "TRILLION" };
        static public HashSet<string> months = new HashSet<string>() { "january","January","JANUARY","february","February",
                        "FEBRUARY","march", "March","MARCH","april","April","APRIL","may","May","MAY","june","June",
                        "JUNE","july","July","JULY","august","August","AUGUST","september","September",
                        "SEPTEMBER","october","October","OCTOBER","november","November","NOVEMBER","december",
                       "December","DECEMBER", "Jun", "JUN", "jun", "JAN", "jan", "Jan", "FEB","Feb","feb", "SEP", "Sep", "sep",
                        "OCT", "Oct", "oct", "NOV", "Nov", "nov", "DEC", "Dec", "dec"};
        static Dictionary<string, string> monthsToNumber = new Dictionary<string, string>(){ {"january", "01" },{"January", "01" },{"JANUARY", "01" },{"february", "02" },{"February", "02" },
            { "FEBRUARY", "02" },{"march", "03" }, {"March", "03" },{"MARCH", "03" },{"april", "04" },{"April", "04" },{"APRIL", "04" },{"may", "05"},{"May", "05"},{"MAY", "05"},{"june","06" },{"June","06" },
            { "JUNE","06" },{"july", "07"},{"July", "07"},{"JULY", "07"},{"august", "08" },{"August", "08" },{"AUGUST", "08" },{"september", "09" },{"September", "09" },
            { "SEPTEMBER", "09" },{"october", "10" },{"October", "10" },{"OCTOBER", "10" },{"november", "11" },{"November", "11" },{"NOVEMBER", "11" },{"december", "12" },
            { "December", "12" },{"DECEMBER", "12" }, {"Jun", "06" }, {"JUN", "06" }, {"jun", "06" }, {"JAN", "01" }, {"jan", "01" }, {"Jan", "01" }, {"FEB", "02" },{"Feb", "02" },{"feb", "02" }, {"SEP", "09" }, {"Sep", "09" }, {"sep", "09" },
            { "OCT", "10" }, {"Oct", "10" }, {"oct", "10" }, {"NOV", "11" }, {"Nov", "11" }, {"nov", "11" }, {"DEC", "12" }, {"Dec", "12" }, {"dec", "12" }, {"AUG", "08" }, {"Aug", "08" }, {"aug","08" } };
        public HashSet<char> Fixwordlist0 = new HashSet<char>() { '\\','\"','=','+','\'','.','!','?','\n', ',', '|','[',']','(',')','{',
                        '}','&',':','<','>',';', ':','@','&','*','^','#' ,';',' ','`'};
        public HashSet<char> Fixwordlist = new HashSet<char>() { '\"','=','+','\'','!','?','\n', '|','[',']','(',')','{',
                        '}','&',':','<','>',';', ':','@','&','*','^','#' ,';',' ','`'};
        public HashSet<char> Fixwordlistlast = new HashSet<char>() {'\"','=','+','\'','-', '.','!','?','\n', ',', '|','[',']','(',')','{',
                        '}','&',':','<','>',';', ':','@','&','*','^','#' ,';',' ','`'};
        public HashSet<char> unwanted = new HashSet<char>() {'\\','\"','=','+','\'','-', '.','!','?','\n', ',', '|','[',']','(',')','{',
                        '}','&',':','<','>',';', ':','@','&','*','^','#' ,';',' ','`', '\"'};
        public HashSet<string> percent = new HashSet<string>() { "percent", "PERCENT", "Percent", "percentage", "Percentage", "PERCENTAGE" };
        public HashSet<string> distance = new HashSet<string>() {"meter","METER","Meter","CM","KM","cm","km","centimeter", "Centimeter", "CENTIMETER", "inch","Inch","INCH",
              "millimeter","Millimeter","mm","MM","MILLIMETER","Mile","mile","MILE","FEET","Feet","feet","yards","yard","Yard","YARD","Yards","YARDS","decimeter",
                "Decimeter","DECIMETER","meters","METERS","Meters","centimeters", "Centimeters", "CENTIMETERS", "inches","Inches","INCHES",
              "millimeters","Millimeters","mm","MM","MILLIMETERS","Miles","miles","MILES","FEETS","Feets","feets","decimeters",
                "Decimeters","DECIMETERS",};
        public HashSet<string> times = new HashSet<string>() {"second", "Second", "SECOND","sec","Sec","SEC", "millisecond", "Millisecond", "MILLISECOND",
        "minute","minutes","Minute","Minutes","MINUTE","MINUTES","hour","hours","Hour","Hours","HOUR","HOURS","day","Day","days","Days","DAY","DAYS",
        "month","Month","MONTH","monthes","Months","MONTHS","year","Year","YEAR","years","Years","YEARS","semeter","SEMETSER","Semetser",
        "semeters","SEMETSERS","Semetsers","week","weeks","Week","Weeks","WEEK","WEEKS","Millennium","millennium","MILLENNIUM","Millenniums","millenniums","MILLENNIUMS"};
        public HashSet<string> stopwords = new HashSet<string>();
        Stemmer stem;
        private int words_length; // length of words string array.
        private Dictionary<string, double> termsInDoc = new Dictionary<string, double>();
        bool toStem;
        string path;
        public string DocName = "";
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
            termsInDoc = new Dictionary<string, double>();
            string tmp_txt = document.Doc;
            string[] text = tmp_txt.Split(' ', '\n', '\t', '\r');
            for (int i = 0; i < text.Length; i++)
                text[i] = Fixword(text[i]);
            //pre_terms = text.ToList();
            DocName = document.DocID;
            parseText(text, queue);
        }
        private bool IsNumber(string str)
        {
            if (str.Length == 0) return false;
            for (int i = 0; i < str.Length; i++)
            {
                if ((i != 0 && i != str.Length - 1 && str[i] == '.' && str[i] == ',')) continue;
                if (str[i] > '9' || str[i] < '0')
                    return false;
            }
            return true;
        }
        public void parseText(string[] words, int queue)
        {
            words_length = words.Length;
            for (int i = 0; i < words_length; i++)
            {
                term t;
                term.Type type;
                string phrase = "";
                int j = i;                                                                              //duplicate the current index to manipulate it without losing the index
                if (words[i] == null || words[i].Equals("")) { continue; }
                string word = words[j];
                //word = Fixword(word);
                //if (word == null /*|| stopwords.Contains(word.ToLower())*/) continue;
                int len = word.Length;
                if (len > 0 && word[len - 1] == '\n') word = word.TrimEnd('\n');          //remove \n from the end of a word
                if (word == "" || word == "\n" || word[0] == '<' || stopwords.Contains(word)) continue; //stip white characters, tags and stop words
                bool isUpperFirstLetter = word[0] >= 'A' && word[0] <= 'Z' ? true : false;              //checks if the word has a first capital letter
                                                                                                        //checking for rule

                if (hasChar(word, '-') && word[0] != '-')
                {
                    /* 
                     * checked for no first minus '-' to eliminate negative numbers
                     * in this case, we found a range\expression, we'll deal with this here by splitting it and save the terms
                     */
                    if (word.Length <= 1) continue;
                    phrase = SetExp(i, words, out j, queue, out type);
                    words_length = words.Length;
                    i = j;
                    if (phrase.Equals("")) continue;
                    //type = term.Type.expression;
                }
                //else if (word[0] == '\"')
                //{
                //    /*
                //     * our own rule, in case of an expression that start and end with ""
                //     * we need to save it as according to the expression rules
                //     */
                //    phrase = SetQuotationExp(i, words, out j, queue);
                //    words_length = words.Length;
                //    i = j;
                //    if (phrase.Equals("")) continue;
                //    type = term.Type.Quotation;
                //}
                else if (containsNumbers(word))
                {
                    if (Isdistance(words, i))
                    {
                        /* 
                         * the first word contains a number, which means it can apply one of the rules
                         * here i'll check which rule to apply
                         */
                        phrase = Setdistance(words, i, out j);
                        type = term.Type.distance;
                    }
                    else if (Istime(words, i))
                    {
                        phrase = setTime(words, i, out j);
                        type = term.Type.time;
                    }
                    // checking for price existance
                    else if (isPrice(words, i))
                    {
                        /*
                         * we found that word[i] is a price expression
                         * time to call the correct rule method
                         * it will return the string phrase we will use to create the term
                         */
                        phrase = Setprice(i, words, out j);
                        type = term.Type.price;
                    }
                    else if (isPercentage(words, i))
                    {
                        /*
                         * the number is a percentage format
                         * time to call the correct rule method
                         */
                        phrase = Isprecent(words, i, out j);
                        type = term.Type.percentage;
                    }
                    else if (isDate(words, i))
                    {
                        /*
                         * the number is in date format
                         */
                        phrase = ToDate(word, words[i + 1]);
                        j++;
                        type = term.Type.date;
                    }
                    else
                    {
                        /*
                         * which no latter condition is fulfilled, that means the number we found
                         * is a normal number that has to be formatted by the numbers rule
                         * we'll call the rule method here
                         */

                        phrase = NumberSet(word, i, words, out j);
                        if (phrase.Equals("")) { continue; }
                        type = term.Type.number;
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
                        phrase = ToDate(word, words[i + 1]);
                        if (phrase.Equals(""))
                            phrase = toStem ? stem.stemTerm(word) : word;
                        j++;
                        type = term.Type.date;
                    }
                    else
                    {
                        if (word.Length < 1 || (word.Length == 1 && !char.IsLetterOrDigit(word[0]))) continue;
                        phrase = toStem ? stem.stemTerm(word) : word;
                        StringBuilder stringbuilder = new StringBuilder();
                        int len1 = phrase.Length - 1;
                        char c1 = phrase[0];
                        char c2 = phrase[len1];
                        bool c = Char.IsLetterOrDigit(c1) && Char.IsLetterOrDigit(c2);
                        for (int ch = 0; ch < phrase.Length && !c; ch++)
                            if ((phrase[ch] <= '9' && phrase[ch] >= '0') || (phrase[ch] <= 'z' && phrase[ch] >= 'a')
                                || (phrase[ch] <= 'Z' && phrase[ch] >= 'A')) stringbuilder.Append(phrase[ch]);
                        if (!c)
                            phrase = stringbuilder.ToString();
                        if (Model.locations.ContainsKey(phrase))
                        {

                              Location l = Model.locations[phrase];
                            if (Model.locsList[queue].ContainsKey(phrase)) { 
                            if (Model.locsList[queue][phrase].LocationsInDocs.ContainsKey(DocName)) { Model.locsList[queue][phrase].LocationsInDocs[DocName].Add(i); } else { Model.locsList[queue][phrase].LocationsInDocs.TryAdd(DocName, new List<int>() { i }); }
                            }
                            else {
                               
                                Model.locsList[queue].Add(phrase, l);
                                if (Model.locsList[queue][phrase].LocationsInDocs.ContainsKey(DocName)) { Model.locsList[queue][phrase].LocationsInDocs[DocName].Add(i); } else { Model.locsList[queue][phrase].LocationsInDocs.TryAdd(DocName, new List<int>() { i }); }
                            }
                        }
                        type = term.Type.word;
                    }
                }

                if (phrase.Length < 1 || stopwords.Contains(phrase)) continue;

                t = new term(phrase);
                t.Type1 = type;
                if (Model.queueList[queue].ContainsKey(phrase+type))
                {
                    /*
                     * using a dictionary, we should always search a value using a key for ammortized O(1) complexity
                     * the dictionary is implemented as a hash table with chaining
                     * so it should give us the best resaults
                     */
                    t = Model.queueList[queue][phrase+type]; //reference to the original term
                    if (!isUpperFirstLetter) t.IsUpperInCurpus = false;
                    t.AddToPosting(DocName, 1);
                }
                else
                {
                    /*
                     * this is a new tern that needs to be created
                     */
                    t = new term(phrase);
                    t.Type1 = type;
                    if (!isUpperFirstLetter) t.IsUpperInCurpus = false;
                    t.AddToPosting(DocName, 1);
                    Model.queueList[queue].Add(t.Phrase+type, t);
                }
                if (termsInDoc.ContainsKey(phrase+type))
                {
                    termsInDoc[phrase+type] += 1;
                }
                else
                {
                    termsInDoc.Add(phrase+type, 0);
                }

                i = j;
                //Console.WriteLine(word);
            }

            /*
             * at the end of the doc parsing, I should end all opened doc counts for the terms
             */
            //foreach (KeyValuePair<string, term> tn in terms)
            //    tn.Value.addDocumentToPostingList();
            double max = 0;
            double tf = 0;
            foreach (KeyValuePair<string, double> entry in termsInDoc)
            {
                tf = entry.Value;
                max = tf > max ? tf : max;
            }
            Model.docs[DocName].maxTF = max;
            Model.docs[DocName].uniqueTerms = termsInDoc.Count;
            termsInDoc.Clear();
        }

        //TODO: need to implement isDate
        private bool isDate(string[] words, int idx)
        {
            int i = idx + 1;
            if (IsNumber(words[idx]))
            {
                if (i < words_length && months.Contains(words[i]))
                    return true;
            }
            else
            {
                if (i < words_length && IsNumber(words[i]) && months.Contains(words[idx]))
                    return true;
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
            if (words[idx][words[idx].Length - 1] == '%' && IsNumber(words[idx].Remove(0, 1))) return true;
            //bool a = IsNumber(words[idx]);
            //bool b = idx + 1 < words_length;
            //bool c = percent.Contains(words[idx + 1]);
            if (IsNumber(words[idx]) && idx + 1 < words_length && percent.Contains(words[idx + 1]))
                return true;
            return false;
        }
        private bool Istime(string[] words,int idx)
        {
            if (!IsNumber(words[idx])) return false;
            if (idx + 1 < words_length)
                if (times.Contains(words[idx + 1]))
                    return true;
            if (idx + 2 < words_length)
                if (allAmounts.Contains(words[idx + 1]) && times.Contains(words[idx + 2])) return true;
            return false;
        }
        public string setTime(string[]words,int idx,out int j)
        {
            string output = null;
            if (idx + 1 < words_length)
            {
                if (times.Contains(words[idx + 1]))
                {
                    output = words[idx]+" "+ words[idx + 1];
                    j = idx + 1;
                    return output;
                }
            }
                j = idx + 2;
                output = words[idx] +" "+ words[idx + 1] +" "+ words[idx + 2];
            
            return output;
            
        }
        /// <summary>
        /// this method checks if a given word in the words list is a start of a price format
        /// </summary>
        /// <param name="words">the list of words in working on</param>
        /// <param name="idx">the index of the word in the list</param>
        /// <returns></returns>
        private bool isPrice(string[] words, int idx)
        {
            if (words[idx][0] == '$' && IsNumber(words[idx].Remove(0, 1))) return true;
            if (idx + 2 < words_length)
                if (IsNumber(words[idx]) && dollars.Contains(words[idx + 2]) && (million.Contains(words[idx + 1]) || billion.Contains(words[idx + 1]) || trillion.Contains(words[idx + 1]))) return true;
            if (idx + 1 < words_length)
                if (IsNumber(words[idx]) && dollars.Contains(words[idx + 1]))
                    return true;
            return false;
        }
        private bool Isdistance(string[] words, int idx)
        {
            if (!IsNumber(words[idx])) return false;
            if (idx + 1 < words_length)
                if (distance.Contains(words[idx + 1]))
                    return true;
            return false;
        }
        private bool containsNumbers(string s)
        {
            //for (int i = 0; i < s.Length; i++)
            //    if (s[i] <= '9' && s[i] >= '0') return true;
            //return false;
            int len = s.Length;
            for (int i = 0; i < len; i++)
                if ((s[i] > '9' || s[i] < '0') && s[i] != '$' && s[i] != '%' && s[i] != '/' && s[i] != '.' && s[i] != '-' && s[i] != ',') return false;
            return true;
        }
        /// <summary>
        /// checks if the word is all made of upper case letter
        /// </summary>
        /// <param name="input"> the word tested</param>
        /// <returns></returns> 
        /// <summary>
        /// checks of the term is a numeric one
        /// </summary>
        /// <param name="input">cheked term</param>
        /// <returns></returns>
        bool IsRegNumber(string[] words, int idx)
        {
            int index = idx + 1;
            int index2 = idx + 2;
            for (int i = 0; i < words[idx].Length; i++)
            {
                char ch = words[idx][i];
                if ((!(ch >= '0' && ch <= '9') && ch != ',' && ch != '.' && ch != '\\' && ch != '/') || words[idx] == "")
                    return false;
            }
            if (words[index] == "$" || words[index] == "%" || percent.Contains(words[index]) || words[index] == "Dollars"||distance.Contains(words[index]))  { return false; }
            if (allAmounts.Contains(words[index]))
            {
                if (words[index2] == "$" || words[index2] == "%" || percent.Contains(words[index]) || words[index2] == "Dollars") { return false; }
            }
            return true;
        }

        bool IsComNum(string input)
        {
            int len = input.Length;
            for (int i = 0; i < len; i++)
            {
                if (!(input[i] >= '0' && input[i] <= '9') && input[i] != '.' && input[i] != '/')
                    return false;
            }
            return true;
        }
        string Isprecent(string[] words, int idx, out int j)
        {
            if (IsComNum(words[idx]) && IsComNum(words[idx + 1]) && (words[idx + 2] == "%" || percent.Contains(words[idx + 2])))
            { j = idx + 2; return words[idx] + " " + words[j] + "%"; }

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
            input = input.Replace("$", "").Replace("%", "");
            if (input == "") {j=idx; return ""; }
            int option = 0;
            int index = idx + 1;
            var charsToRemove = new string[] { "," };
            foreach (var c in charsToRemove)
            {
                input = input.Replace(c, string.Empty);
            }
            if (idx + 1 == words_length) { option = 0; }
            else if (thousends.Contains(words[index])) { option = 1; }
            else if (million.Contains(words[index])) { option = 2; }
            else if (billion.Contains(words[index])) { option = 3; }
            else if (trillion.Contains(words[index])) { option = 4; }
            Double dbl;
            if (double.TryParse(input, out dbl))
            {
                if (option == 1) { dbl = dbl * 1000; }
                if (option == 2) { dbl = dbl * 1000000; }
                if (option == 3) { dbl = dbl * 1000000000; }
                if (option == 4) { dbl = dbl * 1000000000000; }
                if (dbl >= 1000 && dbl < 1000000) { dbl = dbl / 1000 + (dbl % 1000) * (1 / 1000); j = idx + 1; return (dbl.ToString() + "K"); }
                else if (dbl >= 1000000 && dbl < 1000000000) { dbl = dbl / 1000000 + (dbl % 1000000) * (1 / 1000000); j = idx + 1; return (dbl.ToString() + "M"); }
                else if (dbl >= 1000000000) { dbl = dbl / 1000000000 + (dbl % 1000000000) * (1 / 1000000000); j = idx + 1; return (dbl.ToString() + "B"); }
                else { j = idx; return (dbl.ToString()); }
            }
            double nt;
            if (double.TryParse(input, out nt))
            {
                if (option == 1) { nt = nt * 1000; }
                if (option == 2) { nt = nt * 1000000; }
                if (option == 3) { nt = nt * 1000000000; }
                if (option == 4) { nt = nt * 1000000000000; }
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
                if (option == 4) { nt = nt * 1000000000000; }
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
                if (option == 4) { nt = nt * 1000000000000; }
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
                if (option == 4) { j = idx + 1; return FormatNumber(input) * 1000 + "B"; }
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
            int value = (int)FormatNumber(number);
            // int value = int.Parse(number);                                      //get the numeric value of the year/day
            if (monthsToNumber.ContainsKey(month))
            {
                month = monthsToNumber[month];
            }
            if (number.Length == 1) number = "0" + number;
            if (value > 999)
                sol = value + "-" + month;
            else
                sol = month + "-" + value;
            return sol;
        }
        string Setdistance(string[] words, int idx, out int j)
        {
            j = idx + 1;
            return words[idx] + " " + words[idx + 1];
        }
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
                        if (idx + 1 == words_length && words[idx][0] == '$')
                        {
                            j = idx;
                            val = words[idx].Remove(0, 1);
                            return val + " Dollars";
                        }
                        // string lvl = words[idx + 1].ToUpper();
                        if (million.Contains(words[idx + 1])) { string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (billion.Contains(words[idx + 1])) { amount = amount * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (trillion.Contains(words[idx + 1])) { amount = amount * 1000 * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
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
                        if (idx + 1 == words_length && words[idx][0] == '$')
                        {
                            j = idx;
                            val = words[idx].Remove(0, 1);
                            return val + " Dollars";
                        }
                        // string lvl = words[idx + 1].ToUpper();
                        if (million.Contains(words[idx + 1])) { string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (billion.Contains(words[idx + 1])) { amount = amount * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
                        else if (trillion.Contains(words[idx + 1])) { amount = amount * 1000 * 1000; string x2 = amount.ToString("#,##0.##"); val = x2 + " M"; j = idx + 1; }
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
                if (idx + 1 == words_length) { }
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
                    //string lvl = words[idx + 1].ToUpper();
                    if (million.Contains(words[idx + 1]))
                    {
                        val = words[idx] + " M " + "Dollars";
                        if (US.Contains(words[idx + 2]))
                        { j = idx + 3; }
                        j = idx + 2;
                        return val;
                    }
                    else if (billion.Contains(words[idx + 1]))
                    {
                        if (hasChar(words[idx], '.'))
                        {

                            double value = FormatNumber(words[idx]);
                            value = value * 1000;
                            val = value + " M " + "Dollars";
                            if (US.Contains(words[idx + 2]))
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;
                        }
                        else
                        {

                            double value = FormatNumber(words[idx]);
                            value = value * 1000;
                            val = value + " M " + "Dollars";
                            if (US.Contains(words[idx + 2]))
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;

                        }
                    }
                    else if (trillion.Contains(words[idx + 1]))
                    {
                        if (hasChar(words[idx], '.'))
                        {
                            double value = FormatNumber(words[idx]);
                            value = value * 1000 * 1000;
                            val = value + " M " + "Dollars";
                            if (US.Contains(words[idx + 2]))
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;
                        }
                        else
                        {
                            double value = FormatNumber(words[idx]);
                            value = value * 1000 * 1000;
                            val = value + " M " + "Dollars";
                            if (US.Contains(words[idx + 2]))
                            { j = idx + 3; }
                            j = idx + 2;
                            return val;
                        }
                    }
                    else { val = words[idx] + " Dollars"; j = idx + 1; return val; }
                }

            }
        }
        string SetExp(int idx, string[] words, out int j, int queue, out term.Type type)
        {
            string word = words[idx];
            string[] splittedExpression = word.Split('-');
            string exp = "";
            int part = 0;
            List<string> expression = new List<string>();
            //if its a range then we need to seperate it to both ends and format it with correct rule
            if (splittedExpression.Length == 2 && IsNumber(splittedExpression[0]) && IsNumber(splittedExpression[1]))
            {                                                                                   //for example 6-7 (expression)
                if (splittedExpression[0].Length < 1 || splittedExpression[1].Length < 1) { j = idx + part; type = term.Type.number; return ""; };
                if(unwanted.Contains(splittedExpression[0][0]) || unwanted.Contains(splittedExpression[1][0])) { j = idx + part; type = term.Type.number; return ""; };

                term right, left;
                if (idx + 1 < words_length && months.Contains(words[idx + 1]))
                {
                    left = new term(ToDate(splittedExpression[0], words[idx + 1]));       //term phrase = "6 may" = ToDate will return "06-05"
                    right = new term(ToDate(splittedExpression[1], words[idx + 1]));      //term phrase = "7 may" = ToDate will return "07-05"
                    left.IsUpperInCurpus = false;
                    right.IsUpperInCurpus = false;
                    left.Type1 = term.Type.date;
                    left.Type1 = term.Type.date;
                    type = term.Type.expression;
                }
                else if (isPercentage(words, idx))
                {
                    left = new term(splittedExpression[0] + "%");                               //term phrase = "6%"
                    right = new term(splittedExpression[1] + "%");                              //term phrase = "7%"
                    left.IsUpperInCurpus = false;
                    right.IsUpperInCurpus = false;
                    left.Type1 = term.Type.percentage;
                    right.Type1 = term.Type.percentage;
                    type = term.Type.expression;
                }
                else if (isPrice(words, idx))
                {
                    words[idx] = splittedExpression[0];
                    left = new term(Setprice(idx, words, out part));                            //term phrase = "6 million dollars"
                    words[idx] = splittedExpression[1];
                    right = new term(Setprice(idx, words, out part));                           //term phrase = "7 million dollars"
                    left.IsUpperInCurpus = false;
                    right.IsUpperInCurpus = false;
                    left.Type1 = term.Type.price;
                    right.Type1 = term.Type.price;
                    type = term.Type.expression;
                }
                else
                {
                    left = new term(Fixword(splittedExpression[0]));                                     //normal range
                    right = new term(Fixword(splittedExpression[1]));
                    right.Phrase = right.Phrase.Replace(",", "").Replace("\"", "").Replace(",", "");
                    left.Phrase = left.Phrase.Replace(",", "").Replace("\"", "").Replace(",", "");
                    left.IsUpperInCurpus = left.Phrase[0] >= 'A' && left.Phrase[0] <= 'Z' ? true : false;
                    right.IsUpperInCurpus = right.Phrase[0] >= 'A' && right.Phrase[0] <= 'Z' ? true : false;
                    left.Type1 = term.Type.number;
                    right.Type1 = term.Type.number;
                    type = term.Type.range;
                }
                if(!stopwords.Contains(left.Phrase))
                    AddTerm(queue, left);
                if(!stopwords.Contains(right.Phrase))
                    AddTerm(queue, right);
                j = part + idx;
                return Fixword(word.Replace("\"",""));                                                                //returns the whole expression
            }
            StringBuilder sb = new StringBuilder();
            List<string> newWords = new List<string>();
            for (part = 0; part < splittedExpression.Length; part++)                    //when we meet an expression we need to format it is an expression
            {
                exp = splittedExpression[part];                                         //taking the i word of the expression
                if (exp.Equals("") || exp.Equals("-")) continue;
                if(!Char.IsLetterOrDigit(exp[0]) || !Char.IsLetterOrDigit(exp[exp.Length-1]))
                {
                    StringBuilder stringbuilder = new StringBuilder();
                    for (int ch = 0; ch < exp.Length; ch++)
                        if ((exp[ch] <= '9' && exp[ch] >= '0') || (exp[ch] <= 'z' && exp[ch] >= 'a')
                            || (exp[ch] <= 'Z' && exp[ch] >= 'A')) stringbuilder.Append(exp[ch]);
                    exp = stringbuilder.ToString();
                }
                sb.Append(exp);
                if (part + 1 < splittedExpression.Length)
                    sb.Append("-");
                if (toStem)                                                             //stem if needed
                    exp = stem.stemTerm(exp);
                //term t = new term(exp);
                //AddTerm(queue, t);                                      //adding a new term or updating an existing term
                newWords.Add(exp);
            }
            parseText(newWords.ToArray(), queue);
            j = 1 + idx;                                                                   //returns the index
            type = term.Type.expression;
            if (sb.ToString().Length < 3) return "";
            return sb.ToString();
        }
        void AddTerm(int queue, term t)
        {
            //t.AddToPosting(DocName, 1);
            //Model.queueList[queue].AddOrUpdate(t.Phrase, t, (key, value) => {
            //    value.AddToPosting(DocName, 1);
            //    if (!(t.Phrase[0] >= 'A' && t.Phrase[0] <= 'Z')) value.IsUpperInCurpus = false;
            //    return value;
            //});
            string s = t.Phrase;
            term.Type type = t.Type1;
            if (Model.queueList[queue].ContainsKey(s+ type.ToString()))
            {
                /*
                 * using a dictionary, we should always search a value using a key for ammortized O(1) complexity
                 * the dictionary is implemented as a hash table with chaining
                 * so it should give us the best resaults
                 */
                t = Model.queueList[queue][s + t.Type1]; //reference to the original term
                if (!(s[0] <= 'Z' && s[0] >= 'A')) t.IsUpperInCurpus = false;
                t.AddToPosting(DocName, 1);
            }
            else
            {
                /*
                 * this is a new tern that needs to be created
                 */
                t = new term(s);
                t.Type1 = type;
                if (!(s[0] <= 'Z' && s[0] >= 'A')) t.IsUpperInCurpus = false;
                t.AddToPosting(DocName, 1);
                Model.queueList[queue].Add(s +type.ToString(), t);
            }
        }
        //string SetQuotationExp(int idx, string[] words, out int j, int queue)
        //{

        //    // TODO: remove this line after debug
        //    //Console.WriteLine("Pasring an expression at doc: " + DocName + " starting at: " + words[idx]);
        //    string exp = "";
        //    bool expEnd = false;                                                        //will check if the end word has been reached 
        //    List<string> newWords = new List<string>();
        //    StringBuilder ex = new StringBuilder();
        //    int i = idx;
        //    int k = 0;
        //    for (; i < words_length && !expEnd; i++)
        //    {
        //        string word = words[i];
        //        if (word.Equals("")) continue;
        //        if (word[word.Length - 1] == '\"' || hasEndQu(word))
        //        {
        //            word = TrimAll(word);
        //            expEnd = true;
        //        }
        //        if (i == idx)
        //            word = word.Trim('.', '!', '?', '\n', ',', '|', '[', ']', '(', ')', '{',
        //            '}', '&', ':', '<', '>', '@', '&', '*', '^', '#', ';', ' ', '\"');
        //        //word = Fixword(word);
        //        newWords.Add(word);
        //        ex.Append(word);
        //        ex.Append(" ");
        //       // Console.WriteLine("Term seperated: "+word);

        //        /*if(i==idx)
        //            newWords.Add(word.Remove(0,1));
        //        if (expEnd)
        //            newWords.Add(word.Remove(word.Length - 1));*/
        //    }
        //  //  Console.WriteLine("Sending the seperated terms to parse");

        //    parseText(newWords.ToArray(), queue);                                       //will parse the new list in case for double rule
        //    j = i - 1;
        //    ex.Replace("\"", "");
        //    ex.Replace(",", "");
        //  //  Console.WriteLine("Term: " + ex.ToString());
        //    return newWords.Count > 1 ? ex.ToString() : "";

        //}
        //private bool hasEndQu(string word)
        //{
        //    int len = word.Length;
        //    for (int i = len - 1; i >= 0; i--)
        //    {
        //        if (Char.IsLetterOrDigit(word[i])) return false;
        //        if (word[i] == '"') return true;
        //    }
        //    return false;
        //}
        private string TrimAll(string word)
        {
            int len = word.Length;
            for (int i = len - 1; i >= 0;)
            {
                char c = word[i];
                if (Char.IsLetterOrDigit(c)) break;
                word = word.Replace(c + "", "");
                i = word.Length - 1;
            }
            return word;
        }
        string Fixword(string word)
        {
            word=word.Replace("\'", "");
            word=word.Replace("--", "");
            word = word.Replace("..", "");


            if (word == "" || word == "\n" || word[0] == '<') { return ""; }
            if (word.Length <= 1 && (Char.IsLetterOrDigit(word[0]))) return word;
            else if (word.Length <= 1 && !(Char.IsLetterOrDigit(word[0]))) return "";
            else
            {
                word = TrimtoRemove(word);
            }
            if (word != "")
            {
                return word;
            }
            return "";
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
            int len = num.Length;
            for (int i = len - 1; i > floatingPoint; i--)
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
                int len1 = len - floatingPoint - 1;
                number *= Math.Pow(10, -1 * len1);
            }
            return number;
        }
        private string TrimtoRemove(string word)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (i == 0)
                {
                    if (!Fixwordlist0.Contains(c) &&(c!='-'&&word[i+1]!='-'))
                    {
                        if (c == '-' && word[i + 1] == '-') { i++;continue;}
                        if (c == '.' && word[i + 1] == '.') { i++; continue; }
                        sb.Append(c);
                    }
                }
                else if (i == word.Length - 1)
                {
                    if (!Fixwordlistlast.Contains(c))
                    {
                        if (c == '-' && word[i + 1] == '-') { i++; continue; }
                        if (c == '.' && word[i + 1] == '.') { i++; continue; }
                        sb.Append(c);
                    }
                }
                else
                {
                    if (!Fixwordlist.Contains(c))
                    {
                        if (c == '-' && word[i + 1] == '-') { i++; continue; }
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();
        }
        public static bool hasChar(string word, char del)
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