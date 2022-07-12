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
         //   Console.WriteLine("All words are sorted and written to a file WordsSort.txt");
            return listWords;
        }

        public static void FindWordsSort(string text)        
        {
            ReaderWriter.WriteWords("WordsSort", FindWords(text));          
        }

        public static List<string> FindSentence(string text)
        {          
            var result = "";
            Regex regex1 = new Regex(@"\t+");
            Regex regex2 = new Regex(@"\n+");
            result = regex1.Replace(text, " ");
            result = regex2.Replace(result, " ");

            var listSentence = new List<string>(result.Replace("\"","").Replace("|", "").Split(new char[] { '!', '.', '?', }));
            ReaderWriter.WriteAll("AllSentence", listSentence);
           // Console.WriteLine("All sentence are written to the file AllSentence.txt");
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
          //  Console.WriteLine("All characters are written to the file AllSings.txt");
        }

        public static string FindMax(string text)
        {
            List<string> textList = FindSentence(text);   

            var orderedNumbers = from i in textList
                                 orderby i.Length
                                 select i;
            var last = orderedNumbers.Last();
        //  Console.WriteLine($"Longest sentence by number of characters{last}");
            return last;
        }

        public static string FindMin(string text)
        {
            var textList = FindSentence(text);           
            var wordsList = new List< string> { };
            var i = 0;
            var min = 1000;
            var length = 0;
            var index = 0;
            foreach (var elm  in textList)
            {
                length = FindWords(elm).Count;           
                    if (length < min && length>1)
                    {
                        min = length;
                        index = i;
                    }
                        i++;          
            }
            var minSentence = textList.ElementAt(index);
           // Console.WriteLine( $"Shortest sentence by number of words {minSentence}");
            return minSentence;
        }
        public static string FindChar(string text) 
        {
            var i = 0;           
            var result = "";
            Regex regex1 = new Regex(@"\W+");
            Regex regex2 = new Regex(@"\d");
            Regex regex3 = new Regex(@"\s+");
            result = regex1.Replace(text, "");
            result = regex2.Replace(result, "");
            result = regex3.Replace(result, "");
            var charList = result.Replace("_","").ToLower().ToCharArray();  
            var query =( from x in charList
                         group x by x into res
                         orderby res.Count()
                         select new { Name = res.Key, Repeats = res.Count() });
          /*  foreach (var elm in query)
            {
                Console.WriteLine($"Word: {elm.Name} repeats: {elm.Repeats}");
                i++;                
            }*/
            var last=query.Last().Name.ToString();
           // Console.WriteLine($"Most common letter {last}");
            return last;
        }

    }
}
