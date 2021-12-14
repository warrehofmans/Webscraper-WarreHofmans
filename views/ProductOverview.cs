using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.helpers;
using Webscraper_ConsoleApplication.model;
using Webscraper_ConsoleApplication.service;

namespace Webscraper_ConsoleApplication.views
{
    class ProductOverview
    {
        public static void printFilters()
        {
            Console.Clear();
            Console.WriteLine("Choose a filter:");
            var count = 1;
            foreach (KeyValuePair<string, string> filter in Product.avaibleFilters)
            {
                Console.WriteLine(count + ") " + filter.Key);
                if (!FilterTranslation.initialized)
                {
                    FilterTranslation.translationFilters.Add(count, filter.Key);
                }
               
                count++;
            }
            FilterTranslation.initialized = true;
        }


        public static void printProduct(ProductItem item, int count)
        {
            Console.WriteLine("******* Product " + count + " *******");
            Console.WriteLine("Title: " + item.title);
            Console.WriteLine("Creator: " + item.creator);
            Console.WriteLine("Price: €" + item.price);
            Console.WriteLine("Delivery: " + item.delivery);
            Console.WriteLine("Product url: " + item.url);
            Console.WriteLine("\n");
        }

        public static void printProduct(ProductItem item)
        {
            Console.WriteLine(item.id + ")");
            Console.WriteLine("Title: " + item.title);
            Console.WriteLine("Creator: " + item.creator);
            Console.WriteLine("Price: €" + item.price.Replace(" ", String.Empty));
            Console.WriteLine("Delivery: " + item.delivery);
            Console.WriteLine("Product url: " + item.url);
            Console.WriteLine("\n");
        }

        public static void searchHeader()
        {
            Console.Clear();
            Console.WriteLine("What product you would like to search?");
        }

        public static void defaultFilter()
        {
            Console.Clear();
            Console.WriteLine("De default filter was set: revalance");
        }



    }
}
