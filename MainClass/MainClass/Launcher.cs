using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using MainClass;

namespace Task2._1
{
    class Launcher
    {
        string allFile;
        string[] sentences;

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();

            launcher.ReadFile();
            launcher.ConvertUppercaseToLowercase();
            launcher.SplitFileToSentences();
            launcher.AddDateTimeToSentences();
            
            Console.ReadLine();
        }

        void ReadFile()
        {
            allFile = File.ReadAllText(Resource.Path);
            Console.WriteLine("All file: \n" + allFile + "\n");
        }

        void ConvertUppercaseToLowercase()
        {
            string str = allFile.ToLower();
            Console.WriteLine($"Text after change uppercase letters to lowercase: \n{str} " +  "\n");
        }

        void SplitFileToSentences()
        {
            int i = 0;
            string pattern = @"(?<=[\.!\?])\s+";

            sentences = Regex.Split(allFile, pattern);
            Console.WriteLine($"Text after split sentences: \n " );
            while (i < sentences.Length)
            {
                Console.WriteLine(sentences[i]);
                i++;
            }

            Console.WriteLine();
        }

        void AddDateTimeToSentences()
        {
            int i = 0;
            Console.WriteLine($"Text after added date and time to sentences: \n ");
            while (i < sentences.Length)
            {
                string currentDate = DateTime.Now.ToString("dd.MM.yyyy H:mm:ss:fff");
                Console.WriteLine(currentDate + " " + sentences[i]);
                i++;
            }
        }
    }
}
