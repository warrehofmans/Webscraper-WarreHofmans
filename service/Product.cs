using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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

        private ProductItemRepository productItemRepository = new ProductItemRepository();

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
            waitLoaded();
            scrollPage();

            products = collectProducts();
            if (!checkResultEmpty(products)) { Print.printNoResults(); }

            //loop over results
            var counter = 0;
            var helpCounter = 0;
            while (helpCounter < products.Count && helpCounter < amountProducts)
            {

                var product = products[counter];
                counter++;

                //print object

                ProductItem productItem = new ProductItem
                {

                    title = getTitle(product),
                    creator = getCreator(product),
                    price = getPrice(product),
                    delivery = getDelivery(product),
                    url = getUrl(product)
                };
                ProductOverview.printProduct(productItem, helpCounter + 1);

                //save to database
                productItemRepository.InsertProductItem(productItem);
                helpCounter++;
            }
        }

        private ReadOnlyCollection<IWebElement> collectProducts()
        {
            var prevVids = 0;
            do
            {
                scrollPage();
                products = collectProductsPage();
                if (products.Count == prevVids)
                {
                    return products;
                }
                prevVids = products.Count;
            }
            while (!checkResult());

            return products;
        }

        private ReadOnlyCollection<IWebElement> collectProductsPage()
        {
            By element = By.CssSelector(".product-item--row");
            return driver.FindElements(element);
        }

        private string getTitle(IWebElement product)
        {
            IWebElement element = product.FindElement(By.CssSelector(".product-title"));
            return element.Text;
        }

        private string getUrl(IWebElement product)
        {
            IWebElement element = product.FindElement(By.CssSelector(".product-title"));
            return element.GetAttribute("href");
        }

        private string getCreator(IWebElement product)
        {
            IWebElement element = product.FindElement(By.CssSelector(".product-creator"));
            return element.Text;
        }

        private string getDelivery(IWebElement video)
        {
            IWebElement element = video.FindElement(By.CssSelector(".product-delivery"));
            return element.Text;
        }

        private string getPrice(IWebElement product)
        {
            try
            {
                IWebElement element = product.FindElement(By.CssSelector(".price-block meta"));
                return element.GetAttribute("content");
            }
            catch 
            {
                return "*";
            }
           
        }

        private bool checkResult()
        {
            return products.Count > amountProducts;
        }
    }
}
