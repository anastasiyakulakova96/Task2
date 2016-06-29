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
        string line = "";
        string allLines = "";
        string[] a = { ".", "," };
        string[] all;
        int numInt;
        double numDouble;
        string comp = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

        List<string> list;
        List<string> listOfStrings;
        List<string> splitList;
        List<int> listOfIntager;
        List<double> listOfDouble;
     




        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            launcher.WriteLine();
            launcher.SplitLines();
            launcher.SearchCountOfIntegerNumbers();

            launcher.SearchCountOfDoubleNumbers();
            launcher.ShowIntNumbers();
            launcher.ShowDoubleNumbers();


            launcher.SearchCountOfString();
            
            Console.ReadLine();




        }


        void WriteLine()
        {
            splitList = new List<string>();
            list = new List<string>();
            Console.WriteLine($"enter line. if you want exit enter 'end' and key 'Enter'. Please enter double numbers with '{comp}'");

            do
            {
                allLines = line + " " + allLines;
                line = Console.ReadLine();
            }
            while (!line.Equals("end"));

            // Console.WriteLine(allLines);




        }


        public void SplitLines()
        {
            all = allLines.Split(' ');

            for (int i = 0; i < all.Length; i++)
            {
                splitList.Add(all[i]);
            }

            //splitList.ForEach(delegate (String name)
            //{
            //    Console.WriteLine("разделенный "+name);
            //});
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
            Console.WriteLine("Count integer number: " + listOfIntager.Count);

            return listOfIntager;
        }



        public List<double> SearchCountOfDoubleNumbers()
        {
             listOfDouble = new List<double>();

            foreach (var item in splitList)
            {

                if (item.Contains(".") || item.Contains(","))
                {
                    if (Double.TryParse(item, out numDouble)) {
                        listOfDouble.Add(numDouble);
                    }
                    
                }
            }

            Console.WriteLine("Count float number: " + listOfDouble.Count);

            return listOfDouble;
        }

        public List<string> SearchCountOfString()
        {
            listOfStrings = new List<string>();

            foreach (var item in splitList)
            {
                if (!Int32.TryParse(item, out numInt) && !((item.Contains(".") || item.Contains(",")) && Double.TryParse(item, out numDouble)))
                {
                    listOfStrings.Add(item);
                }
            }


            var l = listOfStrings.OrderBy(x => x.Length).ThenBy(x => x);
            Console.WriteLine("not numbers: ");

            foreach (var a in l)
            {
                Console.WriteLine(a);
            }


            return listOfStrings;
        }

        public void ShowIntNumbers()
        {
            int sum = 0;
            float avg = 0;

            Console.WriteLine("integer numbers: ");
            foreach (int s in listOfIntager)
            {
                sum = listOfIntager.Sum();
                Console.WriteLine(s.ToString().PadLeft(90));
            }
            avg = (float)sum / listOfIntager.Count();

            Console.WriteLine("average " + avg.ToString().PadLeft(85));

        }


        public void ShowDoubleNumbers()
        {
            double sum = 0;
            double avg = 0;

            Console.WriteLine("double numbers: ");
            foreach (int s in listOfDouble)
            {
                sum = listOfDouble.Sum();
                Console.WriteLine(s.ToString("0.00").PadLeft(90));
            }
            avg = (double)sum / listOfDouble.Count();
           // Console.WriteLine(AverageOfDouble(list).ToString("0.00").PadLeft(90));
            Console.WriteLine("average " + avg.ToString("0.00").PadLeft(85));
        }

       


    }
}



  //for (int i = 0; i<all.Length; i++)
  //          {

  //             if (all[i].Contains(".")|| all[i].Contains(","))
  //              {
  //                  foreach (var item in splitList)
  //                  {
  //                      if (float.TryParse(item, out num))
  //                      {
  //                          listOfFloat.Add(num);
  //                        //  Console.WriteLine("num: " + num);
  //                      }
  //                  }
  //                      Console.WriteLine("Count float number: " + listOfFloat.Count);

  //              }
  //          }


//while (true)
//{
//    Console.WriteLine("What you want do?\n"
//        + "1 - Enter lines \n "
//        + "2 - \n"
//        + "3 - exit\n");
//    ConsoleKeyInfo consoleKey = Console.ReadKey();
//    switch (consoleKey.Key)
//    {
//        case ConsoleKey.D1:
//            launcher.WriteLine();
//            break;
//        case ConsoleKey.D2:
//            launcher.SplitLines();
//            break;
//        case ConsoleKey.D3:
//            return;
//        default:
//            Console.WriteLine("Default case");
//            break;
//    }
//}


//void SearchCountOfFloatNumbers1()
//{
//   int i = 0;
//    foreach (String s in allLines.Split(' '))
//    {
//        string str = s.Replace('.', ',');
//        if (IsFloat(str)) i++;
//    }
//    Console.WriteLine("\nFloat numbers: " + i);
//}


//public static bool IsFloat(string sValue)
//{
//    Regex objReg = new Regex(@"(-|)[0-2],\d{1,2}");
//    Match objMatch = objReg.Match(sValue);
//    return objMatch.Success;
//}