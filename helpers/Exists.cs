using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.model;

namespace Webscraper_ConsoleApplication.helpers
{
    class Exists
    {
        /*local sets to save all avaible video's, products and jobs*/
        private static HashSet<int> videos = new HashSet<int>();
        private static HashSet<int> jobs = new HashSet<int>();
        private static HashSet<int> products = new HashSet<int>();

        
        /*Check if video exists*/
        public static bool videoExists(int video)
        {
            /*Video in set */
            if (videos.Contains(video))
            {
                return true;
            }
            /*Not in set*/
            Print.notExist();
            return false;
        }

        /*Add video to set*/
        public static bool addVideo(int video)
        {
            return videos.Add(video);
        }

        /*Remove video from set*/
        public static bool removeVideo(int video)
        {
            return videos.Remove(video);
        }

        /*Clear video set*/
        public static void clearVideos()
        {
            videos = new HashSet<int>();
        }

        /*check if job in set*/
        public static bool jobExists(int job)
        {
            /*Job in set*/
            if (jobs.Contains(job))
            {
                return true;
            }
            /*Job not in set*/
            Print.notExist();
            return false;
        }

        /*Add job to set*/
        public static bool addJob(int job)
        {
            return jobs.Add(job);
        }

        /*Remove job from set*/
        public static bool removeJob(int job)
        {
            return jobs.Remove(job);
        }

        /*Clear job set*/
        public static void clearJobs()
        {
            jobs = new HashSet<int>();
        }

        /*check if product in set*/
        public static bool productExists(int product)
        {
            /*Product in set*/
            if (products.Contains(product))
            {
                return true;
            }
            /*Product not in set*/
            Print.notExist();
            return false;
           
        }

        /*Add product to set*/
        public static bool addProduct(int product)
        {
            return products.Add(product);
        }

        /*Remove product from set*/
        public static bool removeProduct(int product)
        {
            return products.Remove(product);
        }

        /*Clear product set*/
        public static void clearProducts()
        {
            products = new HashSet<int>();
        }
    }
}
