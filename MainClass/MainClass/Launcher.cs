using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MainClass
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


            //while (true)
            //{
            //    Console.WriteLine("What you want do?\n"
            //        + "1 - Change uppercase letters to lowercase\n "
            //        + "2 - Split file to sentences \n"
            //        + "3 - exit\n");
            //    ConsoleKeyInfo consoleKey = Console.ReadKey();
            //    switch (consoleKey.Key)
            //    {
            //        case ConsoleKey.D1:
            //            pr.LowLetter(pr.allFile);
            //            break;
            //        case ConsoleKey.D2:
            //            pr.SplitFile(pr.allFile);
            //            break;
            //        case ConsoleKey.D3:
            //            return;
            //        default:
            //            Console.WriteLine("Default case");
            //            break;
            //    }
            //}

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
            Console.WriteLine("Change uppercase letters to lowercase: \n " + str + "\n");
        }

        void SplitFileToSentences()
        {
            int i = 0;
            string pattern = @"(?<=[\.!\?])\s+";

            sentences = Regex.Split(allFile, pattern);

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
            while(i < sentences.Length)
            {
                string currentDate = DateTime.Now.ToString("dd.MM.yyyy H:mm:ss:fff");
                Console.WriteLine(currentDate + " " + sentences[i]);
                i++;
            }
        }
    }
}
