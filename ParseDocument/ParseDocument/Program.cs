using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParseDocument
{
    class Program
    {
        static void Main(string[] args)
        {

            // SplitText.FindWords(ReaderWriter.Read());

            // SplitText.FindWordsSort(ReaderWriter.Read());
            //
            ///  SplitText.FindSentence(ReaderWriter.Read());

            // SplitText.FindSings(ReaderWriter.Read());

            // SplitText.FindMin(ReaderWriter.Read());
            //SplitText.FindChar(ReaderWriter.Read());

            StartWork();


        }
        public static void StartWork()
        {
            var anser = "";
            var input = 0;
            var menuConsole = @$"1-Find Sentence
2-Find Words
3-Find Sings
4-Find Words Sort
5-Longest sentence by number of characters
6-Shortest sentence by number of words
7-Most common letter
8-Final write to file";

            Console.WriteLine(menuConsole);
            if (!int.TryParse(Console.ReadLine(), out input)|| input<1 || input > 8) 
            {
                StartWork();
                return;
            }
            var text = ReaderWriter.Read();
                switch (input)
            {
                case 1:
                    SplitText.FindSentence(text);
                    Console.WriteLine("All sentence are written to the file AllSentence.txt");
                    break;
                case 2:
                    SplitText.FindWords(text);
                    Console.WriteLine("All words are sorted and written to a file WordsSort.txt");
                    break;
                case 3:
                    SplitText.FindSings(text);
                    Console.WriteLine("All characters are written to the file AllSings.txt");
                    break;
                case 4:
                    SplitText.FindWordsSort(text);
                    Console.WriteLine("All Words are written to the file WordsSort.txt");
                    break;
                case 5:                   
                    Console.WriteLine($"Longest sentence by number of characters: { SplitText.FindMax(text)}");
                    break;
                case 6:                   
                    Console.WriteLine($"Shortest sentence by number of words: { SplitText.FindMin(text)}");
                    break;
                case 7:                    
                    Console.WriteLine($"Most common letter: {SplitText.FindChar(text)}");
                    break;
                case 8:
                    ReaderWriter.WriteTotal(text);
                    break;
            }
            do
            {
                Console.WriteLine("Do you wanna repeat? Enter Y/N.");
                anser = Console.ReadLine();
                anser = anser.ToUpper();
            }
            while (anser != "Y" && anser != "N");
            if (anser == "Y") StartWork();
            else Console.WriteLine("The job is done!");
        }
    }
}
