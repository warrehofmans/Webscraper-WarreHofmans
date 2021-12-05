using System;
using System.Collections.Generic;
using Webscraper_ConsoleApplication.DAL;

namespace Webscraper_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

          
            YoutubeVideoRepository youtubeVideoRepository = new YoutubeVideoRepository();
            JobAdvRepository jobAdvRepository = new JobAdvRepository();
            //HashSet<YoutubeVideo> videos = new HashSet<YoutubeVideo>(youtubeVideoRepository.GetYoutubeVideos());
            while (true)
            {
                Print.StartScreen();

                var choice = Console.ReadLine();

                if (choice.ToLower() == "1")
                {

                    Console.WriteLine("Search?");
                    string searchTerm = Console.ReadLine();
                    Youtube youtube = new Youtube(searchTerm);
                    youtube.scrapeYoutube();

                }


                if (choice.ToLower() == "2")
                {

                    Console.WriteLine("Search?");
                    string searchTerm = Console.ReadLine();
                    Jobs jobs = new Jobs(searchTerm);
                    jobs.searchJobs();

                }


                if (choice.ToLower() == "3")
                {

                    Console.WriteLine("All videos:");
                    var testcount = 1;
                    foreach(YoutubeVideo video in youtubeVideoRepository.GetYoutubeVideos())
                    {
                        Print.printVideo(video, testcount);
                        testcount++;
                    }
                   ;

                }


                if (choice.ToLower() == "4")
                {

                    Console.WriteLine("All jobs:");
                    var testcount = 1;
                    foreach (JobAdv job in jobAdvRepository.GetJobAdvs())
                    {
                        Print.printJob(job, testcount);
                        testcount++;
                    }
                   ;

                }
            }
            

            
            
        }
    }
}
