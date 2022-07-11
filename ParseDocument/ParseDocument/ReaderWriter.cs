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
            var str = "";
            using (StreamReader file = File.OpenText($"sample.txt"))
            {
                str = file.ReadToEnd();              
            }
            return str;
          
        }

       public static void Write(string nameFile, List<string> listWords)
        {

            var query = from z in listWords
                        orderby z
                        group z by z into res
                        select new { Name = res.Key, Repeats = res.Count() };


            using (StreamWriter fs = new StreamWriter($"{nameFile}.txt"))
            {
                foreach (var val in query)
                {
                    fs.WriteLine($"Word: {val.Name} repeats: {val.Repeats}");
                }

            }
        }
        public static void WriteAll(string nameFile, List<string> listWords)
        {
                      
            using (StreamWriter fs = new StreamWriter($"{nameFile}.txt"))
            {
                foreach (var val in listWords)
                {
                    fs.WriteLine(val);
                }

            }
        }
  
    }
}
