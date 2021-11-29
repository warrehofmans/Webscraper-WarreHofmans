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

        private void scrollPage()
        {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.documentElement.scrollHeight);");
                Thread.Sleep(2000);

        }

        public void scrapeYoutube(string url)
        {
            driver.Url = url;
            /* Explicit Wait to ensure that the page is loaded completely by reading the DOM state */
            var timeout = 10000; /* Maximum wait time of 10 seconds */
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            scrollPage();

            By elem_video_link = By.CssSelector("ytd-video-renderer");


            //select all video's
            ReadOnlyCollection<IWebElement> videos = driver.FindElements(elem_video_link);

            Console.WriteLine("Total number of videos in " + url + " are " + videos.Count);

            /* Go through the Videos List and scrap the same to get the attributes of the videos in the channel */
            var max = 5;
            var counter = 0;
            var helpCounter = 0;
            while(helpCounter < max)
            {

                var video = videos[counter];

                /*debug info*/
                /*Console.WriteLine(videos.Count);*/
                string title, views, date, vidUrl, uploader;
               
                IWebElement elem_video_title = video.FindElement(By.CssSelector("#video-title"));
                title = elem_video_title.Text;

                IWebElement elem_video_url = video.FindElement(By.CssSelector("#thumbnail"));
                vidUrl = elem_video_title.GetAttribute("href");

                IWebElement elem_video_views = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[1]"));
                views = elem_video_views.Text;

                try
                {
                    IWebElement elem_video_reldate = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[2]"));
                    date = elem_video_reldate.Text;

                    IWebElement elem_video_uploader = video.FindElement(By.XPath(".//*[@id='channel-name']/div/div/yt-formatted-string/a"));
                    uploader = elem_video_uploader.GetAttribute("textContent");

                    Url.printVideo(title, views, date, vidUrl, uploader, helpCounter+1);
                    helpCounter++;
                    
                }
                catch (Exception e)
                {
                  //do nothing
                }
                counter++;



            }


            Console.WriteLine("Scraping Data from LambdaTest YouTube channel Passed");
    }

    }
}
