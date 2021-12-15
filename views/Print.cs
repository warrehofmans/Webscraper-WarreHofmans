using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Print
    {
        static public void StartScreen()
        {
            //**/Console.Clear();
            Console.WriteLine("Make your selection");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Search Youtube video's");
            Console.WriteLine("2 - Search job advertisements");
            Console.WriteLine("3 - Search products");
            Console.WriteLine("4 - Video overview");
            Console.WriteLine("4 - Job overview");
            Console.WriteLine("6 - Product overview");
        }

        public static void printNoResults()
        {
            Console.Clear();
            Console.WriteLine("No results found...");
            Console.WriteLine("\n");
        }


        public static void printResults()
        {
            Console.Clear();
            Console.WriteLine("Results");
            Console.WriteLine("-------");
        }

        public static void wrongFormat()
        {
            clearPrevLine();
            Console.WriteLine("The input is the wrong format - try again");
        }

        public static void notExist()
        {
            clearPrevLine();
            Console.WriteLine("The given id doesn't match a saved item - try again");
        }

        public static void clearPrevLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string (' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }



    }
}

