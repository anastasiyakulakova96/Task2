using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2._2
{
    class Launcher
    {
        string exit = "";
        string allLines="";
        string[] d;
        private int result;

        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            //launcher.WriteLine();
            //launcher.SplitLines();


            while (true)
            {
                Console.WriteLine("What you want do?\n"
                    + "1 - Enter lines \n "
                    + "2 - \n"
                    + "3 - exit\n");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {
                    case ConsoleKey.D1:
                        launcher.WriteLine();
                        break;
                    case ConsoleKey.D2:
                        launcher.SplitLines();
                        break;
                    case ConsoleKey.D3:
                        return;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }


        void WriteLine()
        {
                      while (!exit.Equals(@"/1"))
            {
                Console.WriteLine("enter line. if you want exit enter  '/1' and key 'Enter' ");
                exit = Console.ReadLine();
                allLines = exit + " " + allLines;
                Console.WriteLine(allLines);
            }
            

        }



        void SplitLines()
        {
            //int i = 0;
            //string pattern = " ";
            //int[] n;

            //d = Regex.Split(allLines, pattern);
            ////string s = "123";
            ////int n = Convert.ToInt32(s);
            //int c = int.TryParse(d[0], out result);

            //for (i = 0; i < d.Length; i++)
            //{
            //    int one = d;
            //   if(d[i])
            //}



         

            //while (i < d.Length)
            //{
            //    Console.WriteLine(d[i]);
            //    i++;
            //}
            // int aa = int.TryParse(allLines, out Launcher.result);
            //   if (int.TryParse(allLines, out int result)) { }


        }


        void integerNumbers()
        {

        }

    }
}
