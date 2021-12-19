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
        /*Print: filter overview*/
        public static void printFilters()
        {
            Console.Clear();
            Console.WriteLine("Choose a filter:");
            var count = 1;
            /*Print all filters with key*/
            foreach (KeyValuePair<string, string> filter in Product.avaibleFilters)
            {
                Console.WriteLine(count + ") " + filter.Key);
                /*Check if transalation set is initialized*/
                if (!FilterTranslation.initialized)
                {
                    /*Add filter to translation dictionnary with given key*/
                    FilterTranslation.translationFilters.Add(count, filter.Key);
                }
               
                count++;
            }
            /*Set transaltion to initialized*/
            FilterTranslation.initialized = true;
        }

        /*Print: product info - in search*/
        public static void printProduct(ProductItem item, int count)
        {
            Console.WriteLine("******* Product " + count + " *******");
            Console.WriteLine("Title: " + item.title);
            Console.WriteLine("Creator: " + item.creator);
            Console.WriteLine("Price: " + item.price + " Euro");
            Console.WriteLine("Delivery: " + item.delivery);
            Console.WriteLine("Product url: " + item.url);
            Console.WriteLine("\n");
        }

        /*Print: product info - in overview*/
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

        /*Print: search product header*/
        public static void searchHeader()
        {
            Console.Clear();
            Console.WriteLine("What product you would like to search?");
        }

        /*Print: default header*/
        public static void defaultFilter()
        {
            Console.Clear();
            Console.WriteLine("De default filter was set: revalance");
        }

        /*Print: product overview menu*/
        public static void printProductOverview()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Delete a product? - delete all: a - exit: q");

        }

        /*Print: no products found*/
        public static void NoProductsFound()
        {
            Console.Clear();
            Console.WriteLine("You have no products saved");

        }

        /*Print: product overview header*/
        public static void Header(int count)
        {
            Console.Clear();
            Console.WriteLine("You have " + count + " products saved!");
            Console.WriteLine("-----------------------------------------------------");

        }



    }
}
