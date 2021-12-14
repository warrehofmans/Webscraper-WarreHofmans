﻿using System;
using System.Collections.Generic;
using System.Linq;
using Webscraper_ConsoleApplication.DAL;
using Webscraper_ConsoleApplication.service;
using Webscraper_ConsoleApplication.views;

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

                    var videoList = youtubeVideoRepository.GetYoutubeVideos();

                    if(videoList.Count() == 0)
                    {
                        VideoOverview.NoVideosFound();
                    }
                    else
                    {
                        VideoOverview.Header(videoList.Count());
                        foreach (YoutubeVideo video in videoList)
                        {
                            VideoOverview.printVideo(video);

                        }

                        VideoOverview.printVideoOverview();
                        var id = Console.ReadLine();

                        if (id == "a")
                        {
                            youtubeVideoRepository.ResetYoutubeDb();
                        }
                        while (id != "q" && id != "a")
                        {
                            if(int.TryParse(id, out _) && id != null)
                            {
                                youtubeVideoRepository.DeleteVideo(new YoutubeVideo { id = Int32.Parse(id) });
                                Print.clearPrevLine();
                            }

                            else
                            {
                                Print.wrongFormat();
                                
                            }
                            id = Console.ReadLine();
                        }
                    }
                }

                if (choice.ToLower() == "4")
                {

                    var jobList = jobAdvRepository.GetJobAdvs();

                    if (jobList.Count() == 0) { JobOverview.NoJobsFound(); }
                    else
                    {
                        JobOverview.Header(jobList.Count());

                        foreach (JobAdv job in jobList)
                        {
                            JobOverview.printJob(job);
                        }

                        JobOverview.printJobOverview();
                        var id = Console.ReadLine();

                        if (id == "a")
                        {
                            jobAdvRepository.ResetJobDb();
                        }
                        if (id != "q" && id != "a")
                        {
                            jobAdvRepository.DeleteJob(new JobAdv { id = Int32.Parse(id) });

                        }
                    }
                }

                if (choice.ToLower() == "reset youtube")
                {

                    Console.WriteLine("Reset youtube!");
                    youtubeVideoRepository.ResetYoutubeDb();
                }

                if (choice.ToLower() == "reset")
                {

                    Console.WriteLine("Hard reset!");
                    SqlLiteBaseRepository.dbHardReset();
 
                }


                if (choice.ToLower() == "10")
                {
                    ProductOverview.searchHeader();
                    string searchTerm = Console.ReadLine();
                    Product product = new Product(searchTerm);
  
                    ProductOverview.printFilters();
                    product.selectFilter(Console.ReadLine());
                    product.scrapePoducts();
                }

            }
            

            
            
        }
    }
}
