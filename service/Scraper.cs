using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace Webscraper_ConsoleApplication
{
    class Scraper
    {
        public IWebDriver driver { get; set; }
        public string url { get; set; }
        public string filter { get; set; }
        public string searchTerm { get; set; }

       
        public Scraper()
        {

            InitBrowser();
        }
        public void InitBrowser()
        {
           
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "latest";
            capabilities.AddArguments("headless");
            //capabilities.AddArguments("log-level=OFF");
            capabilities.AddExcludedArgument("disable-popup-blocking");
            Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var path = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) + "\\driver";
            //driver = new ChromeDriver(@path, capabilities);
            //driver = new ChromeDriver(@path, capabilities);
            driver = new ChromeDriver(".",capabilities);

        

        }

        public void setUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void scrollPage()
        {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");
                //Thread.Sleep(2000);

        }

   /*     public void scrollBottom()
        {

            var last_height = (((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.scrollHeight"));
            while (true)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");
                Thread.Sleep(2000);   
                var new_height = ((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.scrollHeight");     
                if (new_height == last_height) { break; }      
                last_height = new_height;
            }
        }*/

        public void waitLoaded()
        {
            var timeout = 2000;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public string makeUrl()
        {
            return url + searchTerm + filter;
        }

       public IWebElement FindElementClick(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            return element;
        }

        public IWebElement FindElement(By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return element;
        }

     /*   public IWebElement FindElementInParent(IWebElement parent, By by)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until( parent => parent.FindElement(by));
            Console.WriteLine("element found" + element.Text);
            return element;
        }*/

       /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement firstResult = wait.Until(e => e.FindElement(By.XPath("//a/h3")));*/

        public bool checkResultEmpty(ReadOnlyCollection<IWebElement> collection)
        {
            return collection.Count > 0;
        }
    }
}
