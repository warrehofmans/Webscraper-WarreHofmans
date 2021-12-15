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

          
            YoutubeVideoRepository youtubeVideoRepository = new YoutubeVideoRepository();
            JobAdvRepository jobAdvRepository = new JobAdvRepository();
            ProductItemRepository productItemRepository = new ProductItemRepository();

            while (true)
            {
                Print.StartScreen();

                var choice = Console.ReadLine();

                //search a youtube video
                if (choice.ToLower() == "1")
                {

                    VideoOverview.printSearch();
                    string searchTerm = Console.ReadLine();
                    Youtube youtube = new Youtube(searchTerm);
                    youtube.scrapeYoutube();

                }

                //search a job advertisement
                if (choice.ToLower() == "2")
                {

                    JobOverview.printSearch();
                    string searchTerm = Console.ReadLine();
                    Jobs jobs = new Jobs(searchTerm);
                    jobs.scrapeJobs();

                }

                //search a product
                if (choice.ToLower() == "3")
                {
                    ProductOverview.searchHeader();
                    string searchTerm = Console.ReadLine();
                    Product product = new Product(searchTerm);

                    ProductOverview.printFilters();
                    product.selectFilter(Console.ReadLine());
                    product.scrapePoducts();
                }

                //youtube video overview
                if (choice.ToLower() == "4")
                {
                    //retrieve all video's
                    var videoList = youtubeVideoRepository.GetYoutubeVideos();

                    //no video's saved
                    if(videoList.Count() == 0)
                    {
                        VideoOverview.NoVideosFound();
                    }
                    else
                    {
                    //print video's
                    VideoOverview.Header(videoList.Count());
                    foreach (YoutubeVideo video in videoList)
                    {
                        VideoOverview.printVideo(video);
                        Exists.addVideo(video.id);

                    }

                    //print menu for deleting
                    VideoOverview.printVideoOverview();

                    //get and validate input
                    var input = validateInput.validateVideoInput();

                    //valide number ==> delete video
                    if(validateInput.checkId(input))
                    {
                        youtubeVideoRepository.DeleteVideo(new YoutubeVideo { id = Int32.Parse(input) });
                        Exists.removeProduct(Int32.Parse(input));
                      
                    }

                    //Delete all
                        if(input == "a")
                    {
                    youtubeVideoRepository.ResetYoutubeDb();
                    Exists.clearVideos();
                    }
                    }
                }


                //job advertisement overview
                if (choice.ToLower() == "5")
                {
                    // retrieve all job adc
                    var jobList = jobAdvRepository.GetJobAdvs();

                    //no saved jobs
                    if (jobList.Count() == 0) { JobOverview.NoJobsFound(); }
                    else
                    {
                        //print saved job advertisements
                        JobOverview.Header(jobList.Count());

                        foreach (JobAdv job in jobList)
                        {
                            JobOverview.printJob(job);
                            Exists.addJob(job.id);
                        }

                        JobOverview.printJobOverview();

                        var input = validateInput.validateJobInput();

                        //Delete all
                        if (input == "a")
                        {
                            jobAdvRepository.ResetJobDb();
                            Exists.clearJobs();
                        }

                        //valide number ==> delete video
                        if (validateInput.checkId(input))
                        {
                            jobAdvRepository.DeleteJob(new JobAdv { id = Int32.Parse(input) });
                            Exists.removeJob(Int32.Parse(input));

                        }
                    }
                }

           

                if (choice.ToLower() == "6")
                {
                    //retrieve all saved products
                    var productList = productItemRepository.GetProductItems();

                    //no results
                    if (productList.Count() == 0) { ProductOverview.NoProductsFound(); }
                    else
                    {
                        //print saved products
                        ProductOverview.Header(productList.Count());

                        foreach(ProductItem product in productList)
                        {
                            ProductOverview.printProduct(product);
                            Exists.addProduct(product.id);
                        }

                        ProductOverview.printProductOverview();
                        var input = validateInput.validateProductInput();

                        //Delete all products
                        if (input == "a")
                        {
                            productItemRepository.ResetProductDb();
                            Exists.clearProducts();
                        }

                        //valide number ==> delete video
                        if (validateInput.checkId(input))
                        {
                            productItemRepository.DeleteProduct(new ProductItem { id = Int32.Parse(input) });
                            Exists.removeProduct(Int32.Parse(input));

                        }
                    }
                }

                if (choice.ToLower() == "reset")
                {

                    Console.WriteLine("Hard reset!");
                    SqlLiteBaseRepository.dbHardReset();
 
                }

                if(choice.ToLower() == "debug")
                {
                    Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                }


              

            }
            

            
            
        }
    }
}
