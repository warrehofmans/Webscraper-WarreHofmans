using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Webscraper_ConsoleApplication
{
    class Scraper
    {
        public IWebDriver driver { get; set; }


        public Scraper()
        {

            InitBrowser();
        }
        public void InitBrowser()
        {
           
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";
            //capabilities.AddArguments("headless");
            //capabilities.AddArguments("log-level=OFF");
            driver = new ChromeDriver(@"../../../driver/", capabilities);
        }

        public void setUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void scrollPage()
        {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");
                Thread.Sleep(2000);

        }

        public void waitLoaded()
        {
            var timeout = 10000;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
