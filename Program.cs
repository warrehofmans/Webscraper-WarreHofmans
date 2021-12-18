using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Webscraper_ConsoleApplication.DAL;
using Webscraper_ConsoleApplication.helpers;
using Webscraper_ConsoleApplication.model;
using Webscraper_ConsoleApplication.service;
using Webscraper_ConsoleApplication.views;

namespace Webscraper_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

          
            /*all repositorie to save and retrieve searched results*/
            YoutubeVideoRepository youtubeVideoRepository = new YoutubeVideoRepository();
            JobAdvRepository jobAdvRepository = new JobAdvRepository();
            ProductItemRepository productItemRepository = new ProductItemRepository();

            while (true)
            {
                /*startscreen*/
                Print.StartScreen();

                /*ask the user for their choice*/
                var choice = Console.ReadLine();

                /*input is not a valid option*/
                while (!"123456".Contains(choice.ToLower()))
                {
                    /*Print wrong choice*/
                    Print.wrongChoice();
                    choice = Console.ReadLine();
                }

                /*Search a youtube video*/
                if (choice.ToLower() == "1")
                {
                    /*ask for search term*/
                    VideoOverview.printSearch();
                    string searchTerm = Console.ReadLine();
                    /*new youtube object to search*/
                    Youtube youtube = new Youtube(searchTerm);
                    /*search and print and save*/
                    youtube.scrapeYoutube();

                }

                /*Search a job advertisement*/
                if (choice.ToLower() == "2")
                {
                    /*ask for a search term*/
                    JobOverview.printSearch();
                    string searchTerm = Console.ReadLine();
                    /*new job object to search*/
                    Jobs jobs = new Jobs(searchTerm);
                    /*search and print and save*/
                    jobs.scrapeJobs();

                }

                /*Search a product*/
                if (choice.ToLower() == "3")
                {
                    /*ask for a search term*/
                    ProductOverview.searchHeader();
                    string searchTerm = Console.ReadLine();
                    /*now product object to search*/
                    Product product = new Product(searchTerm);

                    /*print all avaible filters*/
                    ProductOverview.printFilters();
                    /*read the chosen filter*/
                    product.selectFilter(Console.ReadLine());
                    /*search and print and save*/
                    product.scrapePoducts();
                }

                /*Youtube video overview*/
                if (choice.ToLower() == "4")
                {
                    /*Retrieve all video's*/
                    var videoList = youtubeVideoRepository.GetYoutubeVideos();

                    /*No video's saved*/
                    if(videoList.Count() == 0)
                    {
                        VideoOverview.NoVideosFound();
                    }
                    /*Video's saved! */
                    else
                    {
                    /*Print saved video's*/
                    VideoOverview.Header(videoList.Count());
                    foreach (YoutubeVideo video in videoList)
                    {
                        /*Print video info*/
                        VideoOverview.printVideo(video);
                        /*add video to local set*/
                        Exists.addVideo(video.id);

                    }

                    /*Print menu for deleting*/
                    VideoOverview.printVideoOverview();

                   /*get and validate the user input*/
                   /*Only return the input if it's valid*/
                    var input = validateInput.validateVideoInput();

                    /*input is valid + input is number ==> delete video*/
                    if(validateInput.checkId(input))
                    {
                        /*Delete video from database*/
                        youtubeVideoRepository.DeleteVideo(new YoutubeVideo { id = Int32.Parse(input) });
                        /*DElete video from local set*/
                        Exists.removeVideo(Int32.Parse(input));
                      
                    }

                    /*input is a ==> Delete all*/
                        if(input == "a")
                    {
                        /*Clear the video database*/
                        youtubeVideoRepository.ResetYoutubeDb();
                        /*Clear local set*/
                        Exists.clearVideos();
                    }
                    }
                }


                /*Job advertisement overview*/
                if (choice.ToLower() == "5")
                {
                    /*Retrieve all job advertisements*/
                    var jobList = jobAdvRepository.GetJobAdvs();

                    /*No saved jobs*/
                    if (jobList.Count() == 0) { JobOverview.NoJobsFound(); }
                    /*Saved Jobs!*/                   
                    else
                    {
                        /*Print saved job advertisements*/
                        JobOverview.Header(jobList.Count());

                        foreach (JobAdv job in jobList)
                        {
                            /*Print job advertisement information*/
                            JobOverview.printJob(job);
                            /*Add job to local set*/
                            Exists.addJob(job.id);
                        }

                        /*Print menu for deleting*/
                        JobOverview.printJobOverview();

                        /*get and validate the user input*/
                        /*Only return the input if it's valid*/
                        var input = validateInput.validateJobInput();

                        /*input is valid + input is number ==> delete job*/
                        if (validateInput.checkId(input))
                        {
                            /*Delete job from database*/
                            jobAdvRepository.DeleteJob(new JobAdv { id = Int32.Parse(input) });
                            /*DElete job from local set*/
                            Exists.removeJob(Int32.Parse(input));

                        }

                        /*input is a ==> Delete all*/
                        if (input == "a")
                        {
                            /*Clear jab database*/
                            jobAdvRepository.ResetJobDb();
                            /*CLear local job set*/
                            Exists.clearJobs();
                        }

                       
                    }
                }

           
                /*Product overview*/
                if (choice.ToLower() == "6")
                {
                    /*Retrieve all saved products*/
                    var productList = productItemRepository.GetProductItems();

                    /*No saved products*/
                    if (productList.Count() == 0) { ProductOverview.NoProductsFound(); }
                    /*Saved products!*/
                    else
                    {
                        /*Print saved products*/
                        ProductOverview.Header(productList.Count());

                        foreach(ProductItem product in productList)
                        {
                            /*Print product information*/
                            ProductOverview.printProduct(product);
                            /*Add product to local set*/
                            Exists.addProduct(product.id);
                        }

                        /*Print menu for deleting*/
                        ProductOverview.printProductOverview();
                        /*get and validate the user input*/
                        /*Only return the input if it's valid*/
                        var input = validateInput.validateProductInput();

                        /*input is valid + input is number ==> delete product*/
                        if (validateInput.checkId(input))
                        {
                            /*Delete product from database*/
                            productItemRepository.DeleteProduct(new ProductItem { id = Int32.Parse(input) });
                            /*Delete product from local set*/
                            Exists.removeProduct(Int32.Parse(input));

                        }

                        /*input is a ==> Delete all*/
                        if (input == "a")
                        {
                            /*Clear product database*/
                            productItemRepository.ResetProductDb();
                            /*Clear local product set*/
                            Exists.clearProducts();
                        }

                     
                    }
                }

              

            }
        }
    }
}
