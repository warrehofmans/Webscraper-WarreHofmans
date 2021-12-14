using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Print
    {
        static public void StartScreen()
        {
            Console.WriteLine("Make your selection");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Youtube");
            Console.WriteLine("2 - Jobs");
            Console.WriteLine("3 - Video overview");
            Console.WriteLine("4 - Job overview");
            Console.WriteLine("5 - Product");
            Console.WriteLine("6 - Product overview");
        }

        public static void printNoResults()
        {

            Console.WriteLine("No results found...");
            Console.WriteLine("\n");
        }

        public static void wrongFormat()
        {
            clearPrevLine();
            Console.WriteLine("The input is the wrong format - try again");
        }

        public static void clearPrevLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string (' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


        //DEBIG: get url
        public static void printUrl(Scraper scraper)
        {
            Console.WriteLine(scraper.url);
        }
    }
}

