using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace ParseDocument
{
    class SplitText
    {
        public static List<string> FindWords(string text)
        {

            var result = "";
            Regex regex1 = new Regex(@"_");
            Regex regex2 = new Regex(@"\d");
            Regex regex3 = new Regex(@"\W+");       
            result = regex1.Replace(text, " ");
            result = regex2.Replace(result, " ");            
            result = regex3.Replace(result, " ");       
            var listWords = new List<string>((result.Split(" ")));
            ReaderWriter.WriteAll("AllWords", listWords);
            return listWords;
        }

        public static void FindWordsSort(string text)        
        {
            ReaderWriter.Write("WordsSort", FindWords(text));
        }

        public static List<string> FindSentence(string text)
        {          
            var result = "";
            Regex regex1 = new Regex(@"\t+");
            Regex regex2 = new Regex(@"\n+");
            result = regex1.Replace(text, " ");
            result = regex2.Replace(result, " ");

            var listSentence = new List<string>(result.Split(new char[] { '!', '.', '?', }));
            ReaderWriter.WriteAll("AllSentence", listSentence);
            return listSentence;
        }
        public static void FindSings(string text)
        {
            var result = "";
            Regex regex1 = new Regex(@"\w");
            Regex regex2 = new Regex(@"\n+");
            Regex regex3 = new Regex(@"\s+");
            result = regex1.Replace(text, " ");
            result = regex2.Replace(result, " ");
            result = regex3.Replace(result, " ");
            var listSentence = new List<string>(result.Split(" "));
            ReaderWriter.WriteAll("AllSings", listSentence);
        }

        public static void FindMax(string text)
        {
            List<string> textList = FindSentence(text);   

            var orderedNumbers = from i in textList
                                 orderby i.Length
                                 select i;
        
                Console.WriteLine(orderedNumbers.ToList<string>().Last());
        

        }

        public static void FindMin(string text)
        {
            List<string> textList = FindSentence(text);



        }

    }
}
