using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Url
    {
        public string youtube { get; }
        public string jobs { get; }



        public Url()
        {
            this.youtube = "https://www.youtube.com/results?search_query=";
            this.jobs = jobs;
        }

        public string youtubeSearch(string term)
        {
            var filterTime = "&sp=CAI%253D";
            return youtube + term + filterTime;
        }

        public static void printVideo(string title, string views, string date, string vidUrl, string uploader, int count)
        {
            Console.WriteLine("******* Video " + count + " *******");
            Console.WriteLine("Video Title: " + title);
            Console.WriteLine("Video Views: " + views);
            Console.WriteLine("Video Release Date: " + date);
            Console.WriteLine("Video URL: " + vidUrl);
            Console.WriteLine("Uploader: " + uploader);
            Console.WriteLine("\n");
        }
    }
}
