using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;



namespace Webscraper_ConsoleApplication
{
    class Scraper
    {
        private IWebDriver driver;
   
 
        public Scraper()
        {

            InitBrowser();
        }
        public void InitBrowser()
        {
           
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";
            //capabilities.AddArguments("headless");

            driver = new ChromeDriver(@"../../../driver/", capabilities);
        }

        public void setUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

    }
}
