using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Print
    {
        /*Print: selection menu*/
        static public void StartScreen()
        {
            
            Console.WriteLine("Make your selection");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Search Youtube vides");
            Console.WriteLine("2 - Search job advertisements");
            Console.WriteLine("3 - Search products");
            Console.WriteLine("4 - Video overview");
            Console.WriteLine("5 - Job overview");
            Console.WriteLine("6 - Product overview");
        }

        /*Print: no results found*/
        public static void printNoResults()
        {
            Console.Clear();
            Console.WriteLine("No results found...");
            Console.WriteLine("\n");
        }

        /*Print: wrong choice*/
        public static void wrongChoice()
        {
            clearPrevLine();
            Console.WriteLine("Choose one of the above options");
           
        }

        /*Print: resulst*/
        public static void printResults()
        {
            Console.Clear();
            Console.WriteLine("Results");
            Console.WriteLine("-------");
        }

        /*Print: wrong format*/
        public static void wrongFormat()
        {
            clearPrevLine();
            Console.WriteLine("The input is the wrong format - try again");
        }

        /*Print: does not exists*/
        public static void notExist()
        {
            clearPrevLine();
            Console.WriteLine("The given id doesn't match a saved item - try again");
        }

        /*Clear previous line*/
        public static void clearPrevLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string (' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }



    }
}

