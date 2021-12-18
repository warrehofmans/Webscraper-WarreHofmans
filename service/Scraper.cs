using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Webscraper_ConsoleApplication
{
    class Scraper
    {

        protected IWebDriver driver { get; set; }
        protected string url { get; set; }
        protected string filter { get; set; }
        protected string searchTerm { get; set; }

       
        public Scraper()
        {

            InitBrowser();
        }
        private void InitBrowser()
        {
           
            /*Initialize chrome options*/
            ChromeOptions capabilities = new ChromeOptions();
            /*Most recent browser*/
            capabilities.BrowserVersion = "latest";
            /*Don't open browser window ==> stay background*/
            capabilities.AddArguments("headless");
            /*Disable log and warning messages*/
            capabilities.AddExcludedArgument("enable-logging");
           
            /*Prepare chrome driver with driver manager*/
            new DriverManager().SetUpDriver(new ChromeConfig());
            /*Setup the chrome driver with options*/

            /*Create service for the chrome driver*/
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            /*Disable all options that will give output to our program*/
            service.EnableVerboseLogging = false;
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;

            /*Create chrome driver with service and options*/
            driver = new ChromeDriver(service, capabilities);

        }

        /*Set url of webdriver*/
        protected void setUrl(string url)
        {
            /*Navigate to url*/
            driver.Navigate().GoToUrl(url);
        }

        /*Scrol down on page*/
        protected void scrollPage()
        {
            /*Scroll on page with javascript
             * scroll one window down
             */
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");
           

        }

        /*Wait until page is loaded*/
        protected void waitLoaded()
        {
            /*Timout after */
            var timeout = 2000;
            /*Setup driver wait with timeout*/
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            /*Wait until document state is ready
             * get document state with javascript
             * check if complete
             */
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /*Compose the urel for the driver with:
         * setup url
         * user's searchTrem
         * filter
         */
        protected string makeUrl()
        {
            return url + searchTerm + filter;
        }

        /*Find element and wait until it's clickable*/
        protected IWebElement FindElementClick(By by)
        {
            /*Timpout after in seconds*/
            var timeout = 10;
            /*Setup wait with timeout*/
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            /*Wait untile element is found and clickable
             * user selenium helpers to check condition
             * condition: clickable
             */
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            return element;
        }

        /*Find element and wait until visible*/
        protected IWebElement FindElement(By by)
        {
            /*Timpout after in seconds*/
            var timeout = 10;
            /*Setup wait with timeout*/
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            /*Wait untile element is found and clickable
              * user selenium helpers to check condition
              * condition: visible
            */
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return element;
        }

        /*Check if result is empty
         *empty: false
         *not empty: true
         */
        protected bool checkResultEmpty(ReadOnlyCollection<IWebElement> collection)
        {
            return collection.Count > 0;
        }
    }
}
