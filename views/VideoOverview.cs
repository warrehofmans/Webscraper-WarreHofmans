using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.model;

namespace Webscraper_ConsoleApplication.views
{
    class VideoOverview
    {
        /*Print: search video header*/
        public static void printSearch()
        {
            Console.Clear();
            Console.WriteLine("What term would you like to search video's with?");
        }

        /*Print: video information - in search*/
        public static void printVideo(YoutubeVideo video, int count)
        {
            Console.WriteLine("******* Video " + count + " *******");
            Console.WriteLine("Video type: " + video.type);
            Console.WriteLine("Video Title: " + video.title);

            /*Type is video
             * extra attributes:
             *  -date
             *  -views
            */
            if(video.type == VideoType.video)
            {
                Console.WriteLine("Video Views: " + video.views);
                Console.WriteLine("Video Release Date: " + video.date);
            }
            Console.WriteLine("Video URL: " + video.url);
            Console.WriteLine("Uploader: " + video.uploader);
            Console.WriteLine("\n");
        }

        /*Print: video information - in overview*/
        public static void printVideo(YoutubeVideo video)
        {
            Console.WriteLine(video.id + ")");
            Console.WriteLine("Video type: " + video.type);
            Console.WriteLine("Video Title: " + video.title);
            /*Type is video
            * extra attributes:
            *  -date
            *  -views
           */
            if (video.type == VideoType.video)
            {
                Console.WriteLine("Video Views: " + video.views);
                Console.WriteLine("Video Release Date: " + video.date);
            }
            Console.WriteLine("Video URL: " + video.url);
            Console.WriteLine("Uploader: " + video.uploader);
            Console.WriteLine("\n");
        }

        /*Print: overview video menu*/
        public static void printVideoOverview()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Delete a video statistic? - delete all: a - exit: q");

        }

        /*Print: no videos found*/
        public static void NoVideosFound()
        {
            Console.Clear();
            Console.WriteLine("You have no video statistic saved");

        }

        /*Print: video overview header*/
        public static void Header(int count)
        {
            Console.Clear();
            Console.WriteLine("You have " + count + " video statistics saved!");
            Console.WriteLine("-----------------------------------------------------");

        }
    }
}
