using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.views
{
    class VideoOverview
    {

        public static void printVideo(YoutubeVideo video, int count)
        {
            Console.WriteLine("******* Video " + count + " *******");
            Console.WriteLine("Video Title: " + video.title);
            Console.WriteLine("Video Views: " + video.views);
            Console.WriteLine("Video Release Date: " + video.date);
            Console.WriteLine("Video URL: " + video.url);
            Console.WriteLine("Uploader: " + video.uploader);
            Console.WriteLine("\n");
        }

        public static void printVideo(YoutubeVideo video)
        {
            Console.WriteLine(video.id + ")");
            Console.WriteLine("Video Title: " + video.title);
            Console.WriteLine("Video Views: " + video.views);
            Console.WriteLine("Video Release Date: " + video.date);
            Console.WriteLine("Video URL: " + video.url);
            Console.WriteLine("Uploader: " + video.uploader);
            Console.WriteLine("\n");
        }

        public static void printVideoOverview()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Delete a video statistic? - delete all: a - exit: q");

        }

        public static void NoVideosFound()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("You have no video statistic saved");

        }

        public static void Header(int count)
        {
            Console.WriteLine("You have " + count + " video statistics saved!");
            Console.WriteLine("-----------------------------------------------------");

        }
    }
}
