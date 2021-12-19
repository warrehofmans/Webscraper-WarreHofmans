using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Webscraper_ConsoleApplication.DAL;
using Webscraper_ConsoleApplication.helpers;
using Webscraper_ConsoleApplication.model;
using Webscraper_ConsoleApplication.views;

namespace Webscraper_ConsoleApplication.service
{
    class Product : Scraper
    {
       
        private ReadOnlyCollection<IWebElement> products;
        public static int amountProducts = 10;
        private readonly string filterPrefix = "&view=list&sort=";

        /*All avaible filters*/
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

        private ProductItemRepository productItemRepository = new ProductItemRepository();

        public Product()
        {
        }

        /*contructor
          * set searchterm (user input)
          * base url
      */
        public Product(string searchTerm)
        {
            this.searchTerm = searchTerm;
            this.url = "https://www.bol.com/nl/nl/s/?page=1&searchtext=";
        }

        /*Validate filter*/
        public bool validateFilter(string filter)
        {
            /*Check if number
             * input is tring
             * Try to parse
            */
            if(! int.TryParse(filter, out _))
            {
                /*string not parsable to int*/
                Print.wrongFormat();
                return false;
            }
            /*Parse input to int*/
            int filterKey = Int32.Parse(filter);
            /*Check value of filter
             * min: 1
             * max: lengt of filter translation set
            */
            if(filterKey < 1 | filterKey > FilterTranslation.translationFilters.Count)
            {
                /*Not correct value*/
                return false;
            }
            /*Correct filter*/
            return true;
       
        }

        /*Make filter active*/
        public void selectFilter(string filter)
        {
           /*Check if filter is valid*/
            if (validateFilter(filter))
            {
                /*Filter is valid
                  *filter: filterPrefix + choosen filter
                  *translate chosen filter key to filter name for url
                */
                this.filter = filterPrefix + FilterTranslation.translate(filter);
            }
            else
            {
                /*Filter is invalid: set default filter*/
                setDefault();
            }

        }

        public void setDefault()
        {
            /*Print default warning*/
            ProductOverview.defaultFilter();
            /*Set a default filter*/
            this.filter = filterPrefix + avaibleFilters["relevance"];
        }

        /*Main function*/
        public void scrapePoducts()
        {
            /*Make and go to url*/
            setUrl(makeUrl());
            /*wait until page loaded*/
            waitLoaded();
            /*Scroll on page: make sure enough products are loaded*/
            scrollPage();

            /*Collect products from page*/
            products = collectProducts();

            /*check if product found*/
            if (!checkResultEmpty(products)) { 
                /*No products found!*/
                Print.printNoResults(); } else
            {
                /*Products found!*/
                Print.printResults();
            }

            /*Loop over the products*/
            var counter = 0; //counter, the index of the collection
            while (counter < products.Count && counter < amountProducts)
            {
                /*Retrieve product from collection*/
                var product = products[counter];
         
                /*Make new product object*/
                ProductItem productItem = new ProductItem
                {

                    title = getTitle(product),
                    creator = getCreator(product),
                    price = getPrice(product),
                    delivery = getDelivery(product),
                    url = getUrl(product)
                };
                /*Print product information*/
                ProductOverview.printProduct(productItem, counter + 1);

                /*Save product to database*/
                productItemRepository.InsertProductItem(productItem);
                /*Increase counter*/
                counter++;
            }
        }

        /*Collect product elements from page*/
        private ReadOnlyCollection<IWebElement> collectProducts()
        {
            /*Helper var to prevent stuck in infinite loop
             *  keep track of previous lenght
             *  if previous lenght == current lenght: collected all products
            */
            int prevProds = 0;
            do
            {
                /*If list is initialized*/
                if (products != null)
                {
                    /*Set previous lenght*/
                    prevProds = products.Count;
                }
                /*Collect product elements*/
                products = collectProductsPage();
                /*Scroll down*/
                scrollPage();
                /*Wait until new product's are loaded*/
                Thread.Sleep(1500);
            }
            /*stop loop:
             *   - amount of wanted products reached
             *   - no product left
            */
            while (products.Count < amountProducts && prevProds != products.Count);

            return products;
        }

        /*Collect product elements from page*/
        private ReadOnlyCollection<IWebElement> collectProductsPage()
        {
            /*Selector*/
            By element = By.CssSelector(".product-item--row");
            /*Search elements*/
            return driver.FindElements(element);
        }
        
        /*Get title from product element*/
        private string getTitle(IWebElement product)
        {
            /*Search for title in product element*/
            IWebElement element = product.FindElement(By.CssSelector(".product-title"));
            /*Get text from found element*/
            return element.Text;
        }

        /*Get url from product element*/
        private string getUrl(IWebElement product)
        {
            /*Search for url in product element*/
            IWebElement element = product.FindElement(By.CssSelector(".product-title"));
            /*Get href with url from found element*/
            return element.GetAttribute("href");
        }
        /*Get creator from product element*/
        private string getCreator(IWebElement product)
        {
            /*Search for creator in product element*/
            IWebElement element = product.FindElement(By.CssSelector(".product-creator"));
            /*Get text from found element*/
            return element.Text;
        }
        /*Get delivery from product element*/
        private string getDelivery(IWebElement video)
        {
            /*try search for delivery
             * succes: get delivery
             * fail: set defailt text
            */
            try
            {
                /*Search for delivery in product element*/
                IWebElement element = video.FindElement(By.CssSelector(".product-delivery"));
                /*Get text from found element*/
                return element.Text;
            }
            catch
            {
                /*Set default text*/
                return "not avaible";
            }
           
        }

        /*Get price from product element*/
        private string getPrice(IWebElement product)
        {
            /*try search for delivery
              * succes: get price
              * fail: set default price
            */
            try
            {
                /*Search for price in product element*/
                IWebElement element = product.FindElement(By.CssSelector(".price-block meta"));
                /*Get attribute content from found element
                 * exists of two blocks: .text ==> enter between
                 * attr content ==> no enter
                 */
                return element.GetAttribute("content");
            }
            catch 
            {
                /*Set default price*/
                return "*";
            }
           
        }
    }
}
