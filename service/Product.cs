using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.helpers;
using Webscraper_ConsoleApplication.views;

namespace Webscraper_ConsoleApplication.service
{
    class Product : Scraper
    {
        private int ProductCount;
        /*  private JobAdvRepository jobAdvRepository = new JobAdvRepository();*/
        private readonly string filterPrefix = "&view=list&sort=";
        public static readonly Dictionary<string, string> avaibleFilters = new Dictionary<string, string>()
        {
            { "relevance" , "relevance1" },
             { "popularity" , "popularity1" },
             { "low-high" , "price0" },
             { "high-low" , "price1" },
             { "date" , "release_date1" },
             { "rating" , "rating1" },
             { "ranking" , "wishListRank1" }

        };

        public Product()
        {
        }
        public Product(string searchTerm)
        {
            this.searchTerm = searchTerm;
            this.url = "https://www.bol.com/nl/nl/s/?page=1&searchtext=";
        }

        public bool validateFilter(string filter)
        {
            if(! int.TryParse(filter, out _))
            {
                Print.wrongFormat();
                return false;
            }
            int filterKey = Int32.Parse(filter);
            if(filterKey < 1 | filterKey > FilterTranslation.translationFilters.Count)
            {
                return false;
            }

            return true;
       
        }

        public void selectFilter(string filter)
        {
           
            if (validateFilter(filter))
            {
                this.filter = filterPrefix + FilterTranslation.translate(filter);
            }
            else
            {
                setDefault();
            }

        }

        public void setDefault()
        {
            ProductOverview.defaultFilter();
            this.filter = filterPrefix + avaibleFilters["relevance"];
        }

        public void scrapePoducts()
        {
            setUrl(makeUrl());
        }
    }
}
