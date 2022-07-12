using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ParseDocument
{
    class ReaderWriter
    {
        public static string Read()
        {
            try
            {
                var str = "";
                using (StreamReader file = File.OpenText($"sample.txt"))
                {
                    str = file.ReadToEnd();
                }
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }         
          
        }

       public static void WriteWords(string nameFile, List<string> listWords)
        {
            try
            {
                var query = from x in listWords
                            orderby x
                            group x by x into res
                            select new { Name = res.Key, Repeats = res.Count() };
                using (StreamWriter fs = new StreamWriter($"{nameFile}.txt"))
                {
                    foreach (var val in query)
                    {
                        fs.WriteLine($"Word: {val.Name} repeats: {val.Repeats}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);             
            }

        }
        public static void WriteAll(string nameFile, List<string> listWords)
        {
            try
            {
                using (StreamWriter fs = new StreamWriter($"{nameFile}.txt"))
                {
                    foreach (var val in listWords)
                    {
                        fs.WriteLine(val);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }

        public static void WriteTotal(string text)
        {
            try
            {
                var sentenceMax = SplitText.FindMax(text);
                var sentenceMin = SplitText.FindMax(text);
                var letter = SplitText.FindChar(text);


                using (StreamWriter fs = new StreamWriter("Total.txt"))
                {
                   
                        fs.WriteLine($@"Longest sentence by number of characters:
{sentenceMax}
Shortest sentence by number of words: 
{sentenceMin}
Most common letter: 
{letter}");                 
                }
                Console.WriteLine("Final are written to the file Total.txt ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
