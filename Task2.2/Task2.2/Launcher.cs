using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2._2
{
    class Launcher
    {

        public int numInt;
        public double numDouble;
        public string line = "";
        public string allLines = "";
        public int padLeftForAverage = 90;
        public int padLeftForNumbers = 115;
        public string breakEnterLines = "end";
        public string separatorFirst = ".";
        public string separatorSecond = ",";
        public char separatorForReplaceFirst = '.';
        public char separatorForReplaceSecond = ',';
        public string separatorOnComputer = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

        public List<string> splitList;
        public List<int> listOfIntager;
        public List<double> listOfDouble;
        public List<string> listOfStrings;

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();

            launcher.WriteLines();
            launcher.SplitLines();
            launcher.SearchCountOfIntegerNumbers();
            launcher.SearchCountOfDoubleNumbers();
            launcher.ShowIntegerNumbers();
            launcher.ShowDoubleNumbers();
            launcher.RecordStrintInList();
            launcher.SortString();

            Console.ReadLine();
        }


        public void WriteLines()
        {
            splitList = new List<string>();

            Console.WriteLine("Enter lines.If you want exit press 'Enter' and input 'end' then press 'Enter' again." +
                                $"Please enter double numbers with '{separatorOnComputer}'\n");

            do
            {
                allLines = line + " " + allLines;
                line = Console.ReadLine();
            }
            while (!line.Equals(breakEnterLines));

            Console.WriteLine("");
        }


        public void SplitLines()
        {
            string[] lines = allLines.Split(' ');

            for (int i = 0; i < lines.Length; i++)
            {
                splitList.Add(lines[i]);
            }
        }


        public void SearchCountOfIntegerNumbers()
        {
            listOfIntager = new List<int>();

            foreach (var item in splitList)
            {
                if (Int32.TryParse(item, out numInt))
                {
                    listOfIntager.Add(numInt);
                }
            }

            Console.WriteLine($"Count integer numbers: {listOfIntager.Count}");

        }


        public void SearchCountOfDoubleNumbers()
        {
            listOfDouble = new List<double>();

            foreach (var item in splitList)
            {
                if (item.Contains(separatorFirst) || item.Contains(separatorSecond))
                {
                    string rewriteSeperator = item;
                    if (separatorOnComputer.Equals(separatorFirst))
                    {
                        rewriteSeperator = item.Replace(separatorForReplaceSecond, separatorForReplaceFirst);
                    }
                    else if (separatorOnComputer.Equals(separatorSecond))
                    {
                        rewriteSeperator = item.Replace(separatorForReplaceFirst, separatorForReplaceSecond);
                    }

                    if (Double.TryParse(rewriteSeperator, out numDouble))
                    {
                        listOfDouble.Add(numDouble);
                    }

                }
            }

            Console.WriteLine($"Count double numbers: {listOfDouble.Count} \n");

        }


        public List<string> RecordStrintInList()
        {
            listOfStrings = new List<string>();

            foreach (var item in splitList)
            {
                string rewriteSeperator = item;

                if (separatorOnComputer.Equals(separatorFirst))
                {
                    rewriteSeperator = item.Replace(separatorForReplaceSecond, separatorForReplaceFirst);
                }
                else if (separatorOnComputer.Equals(separatorSecond))
                {
                    rewriteSeperator = item.Replace(separatorForReplaceFirst, separatorForReplaceSecond);
                }

                if (!Int32.TryParse(rewriteSeperator, out numInt)
                    && !((rewriteSeperator.Contains(separatorFirst) || rewriteSeperator.Contains(separatorSecond)) && Double.TryParse(rewriteSeperator, out numDouble)))
                {
                    listOfStrings.Add(rewriteSeperator);
                }
            }
            return listOfStrings;
        }


        public void SortString()
        {
            var sortString = listOfStrings.OrderBy(x => x.Length).ThenBy(x => x);

            Console.WriteLine("Not numbers: ");

            foreach (var i in sortString)
            {
                if (i.Length > 0)
                {
                    Console.WriteLine(i);
                }
            }
        }


        public void ShowIntegerNumbers()
        {
            int sum = 0;
            float avg = 0;

            Console.WriteLine("Integer numbers: ");

            if (listOfIntager.Count != 0)
            {
                foreach (int s in listOfIntager)
                {
                    sum = listOfIntager.Sum();
                    Console.WriteLine(s.ToString().PadLeft(padLeftForNumbers));
                }
                avg = (float)(sum / listOfIntager.Count());
            }

            Console.WriteLine("Average integer numbers: " + avg.ToString().PadLeft(padLeftForAverage) + "\n");
        }


        public void ShowDoubleNumbers()
        {
            double sum = 0;
            double avg = 0;

            if (listOfDouble.Count != 0)
            {
                Console.WriteLine("Double numbers: ");

                foreach (double s in listOfDouble)
                {
                    sum = listOfDouble.Sum();
                    Console.WriteLine(s.ToString("0.00").PadLeft(padLeftForNumbers));
                }

                avg = (double)(sum / listOfDouble.Count());
            }

            Console.WriteLine("Average double numbers: " + avg.ToString("0.00").PadLeft(padLeftForAverage) + "\n");
        }

    }
}



 