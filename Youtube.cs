using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Youtube : Scraper
    {
        private ReadOnlyCollection<IWebElement> videos;
        public static int amountVideos = 5;
        private readonly string url = "https://www.youtube.com/results?search_query=";
        private readonly string filter = "&sp=CAI%253D";
        public string searchTerm;

        public Youtube(string searchTerm)
        {
            this.searchTerm = searchTerm;
        }

        public void scrapeYoutube()
        {
            setUrl(makeUrl());
            waitLoaded();
            scrollPage();

            //select all video's
            videos = collectVideos();

            //check if there are results
            if (!checkResultEmpty()) { Print.printNoResults(); }
            

            //loop over results
            var counter = 0;
            var helpCounter = 0;
            while (helpCounter < videos.Count && helpCounter < amountVideos)
            {
                            
                var video = videos[counter];
                counter++;

                if (!checkStream(video))
                {
                    continue; 
                }

                //print object
                YoutubeVideo youtubeVideo = new YoutubeVideo
                {

                    title = this.getTitle(video),
                    url = this.getUrl(video),
                    uploader = this.getUploader(video),
                    views = this.getViews(video),
                    date = this.getDate(video),
                    number = helpCounter+1
                };

                Print.printVideo(youtubeVideo);

                helpCounter++;
            }
        }

        private ReadOnlyCollection<IWebElement> collectVideos()
        {
            var prevVids = 0;
            do
            {
                scrollPage();
                videos = collectVideosPage();
                if (videos.Count == prevVids)
                {
                    return videos;
                }
                prevVids = videos.Count;
            }
            while (!checkResult());
           
           return videos;
        }

        private ReadOnlyCollection<IWebElement> collectVideosPage()
        {
            By elem_video_link = By.CssSelector("ytd-video-renderer");
            return driver.FindElements(elem_video_link);
        }

        private string getTitle(IWebElement video)
        {
            IWebElement element = video.FindElement(By.CssSelector("#video-title"));
            return element.Text;
        }

        private string getUrl(IWebElement video)
        {
            IWebElement element = video.FindElement(By.CssSelector("#thumbnail"));
           return element.GetAttribute("href");
        }

        private string getViews(IWebElement video)
        {
            IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[1]"));
            return element.Text;
        }

        private string getDate(IWebElement video)
        {
            IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[2]"));
            return element.Text;
        }

        private string getUploader(IWebElement video)
        {
            IWebElement element = video.FindElement(By.XPath(".//*[@id='channel-name']/div/div/yt-formatted-string/a"));
            return element.GetAttribute("textContent");
        }

        private bool checkStream(IWebElement video)
        {
            try
            {
                IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[2]"));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string makeUrl()
        {
            return url + searchTerm + filter;
        }

        private bool checkResultEmpty()
        {
            return videos.Count > 0;
        }

        private bool checkResult()
        {
            return videos.Count > amountVideos;
        }

    }
}
