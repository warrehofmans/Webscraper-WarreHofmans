﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Print
    {
        static public void StartScreen()
        {
            Console.WriteLine("Welcome to my webscraper :)");
            Console.WriteLine("Make your selection");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Youtube");
            Console.WriteLine("2 - Jobs");
            Console.WriteLine("3 - ????");
        }


        public static void printVideo(YoutubeVideo video)
        {
            Console.WriteLine("******* Video " + video.number + " *******");
            Console.WriteLine("Video Title: " + video.title);
            Console.WriteLine("Video Views: " + video.views);
            Console.WriteLine("Video Release Date: " + video.date);
            Console.WriteLine("Video URL: " + video.url);
            Console.WriteLine("Uploader: " + video.uploader);
            Console.WriteLine("\n");
        }

        public static void printNoResults()
        {
            
            Console.WriteLine("No results found...");
            Console.WriteLine("\n");
        }
    }
}
