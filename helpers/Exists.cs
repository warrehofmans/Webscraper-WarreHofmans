using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.model;

namespace Webscraper_ConsoleApplication.helpers
{
    class Exists
    {
        private static HashSet<int> videos = new HashSet<int>();
        private static HashSet<int> jobs = new HashSet<int>();
        private static HashSet<int> products = new HashSet<int>();

        public static bool videoExists(int video)
        {
            if (videos.Contains(video))
            {
                return true;
            }
            Print.notExist();
            return false;
        }

        public static bool addVideo(int video)
        {
            return videos.Add(video);
        }

        public static bool removeVideo(int video)
        {
            return videos.Remove(video);
        }

        public static void clearVideos()
        {
            videos = new HashSet<int>();
        }


        public static bool jobExists(int job)
        {
            if (jobs.Contains(job))
            {
                return true;
            }
            Print.notExist();
            return false;
        }

        public static bool addJob(int job)
        {
            return jobs.Add(job);
        }

        public static bool removeJob(int job)
        {
            return jobs.Remove(job);
        }

        public static void clearJobs()
        {
            jobs = new HashSet<int>();
        }

        public static bool productExists(int product)
        {
            if (products.Contains(product))
            {
                return true;
            }
            Print.notExist();
            return false;
           
        }

        public static bool addProduct(int product)
        {
            return products.Add(product);
        }
        public static bool removeProduct(int product)
        {
            return products.Remove(product);
        }

        public static void clearProducts()
        {
            products = new HashSet<int>();
        }
    }
}
