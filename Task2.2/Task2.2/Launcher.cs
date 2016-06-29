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
        int numInt;
        double numDouble;
        string line = "";
        string allLines = "";

        string separator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

        List<string> splitList;
        List<int> listOfIntager;
        List<double> listOfDouble;
        List<string> listOfStrings;

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();

            launcher.WriteLines();
            launcher.SplitLines();
            launcher.SearchCountOfIntegerNumbers();
            launcher.SearchCountOfDoubleNumbers();
            launcher.ShowIntNumbers();
            launcher.ShowDoubleNumbers();
            launcher.SearchString();
            launcher.SortString();

            Console.ReadLine();
        }


        public void WriteLines()
        {
            splitList = new List<string>();

            Console.WriteLine("Enter lines.If you want exit press 'Enter' and input 'end' then press 'Enter' again." +
                                $"Please enter double numbers with '{separator}'");

            do
            {
                allLines = line + " " + allLines;
                line = Console.ReadLine();
            }
            while (!line.Equals("end"));

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


        public List<int> SearchCountOfIntegerNumbers()
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

            return listOfIntager;
        }


        public List<double> SearchCountOfDoubleNumbers()
        {
            listOfDouble = new List<double>();

            foreach (var item in splitList)
            {
                if (item.Contains(".") || item.Contains(","))
                {
                    string rewriteSeperator = item;
                    if (separator.Equals("."))
                    {
                        rewriteSeperator = item.Replace(',', '.');
                    }
                    else if (separator.Equals(","))
                    {
                        rewriteSeperator = item.Replace('.', ',');
                    }

                    if (Double.TryParse(rewriteSeperator, out numDouble))
                    {
                        listOfDouble.Add(numDouble);
                    }

                }
            }

            Console.WriteLine($"Count double numbers: {listOfDouble.Count} \n");

            return listOfDouble;
        }


        public List<string> SearchString()
        {
            listOfStrings = new List<string>();

            foreach (var item in splitList)
            {
                string rewriteSeperator = item;

                if (separator.Equals("."))
                {
                    rewriteSeperator = item.Replace(',', '.');
                }
                else if (separator.Equals(","))
                {
                    rewriteSeperator = item.Replace('.', ',');
                }

                if (!Int32.TryParse(rewriteSeperator, out numInt)
                    && !((rewriteSeperator.Contains(".") || rewriteSeperator.Contains(",")) && Double.TryParse(rewriteSeperator, out numDouble)))
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


        public void ShowIntNumbers()
        {
            int sum = 0;
            float avg = 0;

            Console.WriteLine("Integer numbers: ");

            if (listOfIntager.Count != 0)
            {
                foreach (int s in listOfIntager)
                {
                    sum = listOfIntager.Sum();
                    Console.WriteLine(s.ToString().PadLeft(115));
                }
                avg = (float)sum / listOfIntager.Count();
            }

            Console.WriteLine("Average integer numbers: " + avg.ToString().PadLeft(90)+"\n");
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
                    Console.WriteLine(s.ToString("0.00").PadLeft(115));
                }

                avg = (double)sum / listOfDouble.Count();
            }

            Console.WriteLine("Average double numbers: " + avg.ToString("0.00").PadLeft(91)+"\n");
        }

    }
}



 