using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Webscraper_ConsoleApplication.DAL;
using Webscraper_ConsoleApplication.model;
using Webscraper_ConsoleApplication.views;

namespace Webscraper_ConsoleApplication
{
    class Youtube : Scraper
    {
        private ReadOnlyCollection<IWebElement> videos;
        public static int amountVideos = 50;
        private  YoutubeVideoRepository youtubeVideoRepository = new YoutubeVideoRepository();

        /*contructor
      * set searchterm (user input)
      * base url
      * base filter
      */
        public Youtube(string searchTerm)
        {
            this.searchTerm = searchTerm;
            this.url = "https://www.youtube.com/results?search_query=";
            this.filter = "&sp=CAI%253D";
           
        }

        /*Main function*/
        public void scrapeYoutube()
        {
            /*Make url + go to url*/
            setUrl(makeUrl());
            /*Wait until page is loaded*/
            waitLoaded();
            /*Scroll page*/
            scrollPage();

            /*Collect videos*/
            //videos = collectVideos();
            collectVideos();

            /*check if there are results*/
            if (!checkResultEmpty(videos)) {
                /*Video's found!*/
                Print.printNoResults(); } else
            {
                /*Video's found!*/
               /* Print.printResults();*/
            }
            

            /*loop found video's*/
            var counter = 0; //index videos list 
            while (counter < videos.Count && counter < amountVideos)
            {
               /*Get video from list*/     
                var video = videos[counter];
      
                /*Make new youtubevideo object*/
                YoutubeVideo youtubeVideo = new YoutubeVideo
                {
                    title = getTitle(video),
                    url = getUrl(video),
                    uploader = getUploader(video),
                };

                /*Check if video is stream
                 * stream:
                 *     - no date
                 *     - no views
                */
                if (checkStream(video))
                {
                    /*Normal video
                     *add:
                     *  - date
                     *  - views
                     *  - type: video
                     */
                    youtubeVideo.views = getViews(video);
                    youtubeVideo.date = getDate(video);
                    youtubeVideo.type = VideoType.video;
                }
                else
                {
                    /*Stream
                    *add:
                    *  - type: stream
                    */
                    youtubeVideo.type = VideoType.stream;
                }

                /*Print video*/
                VideoOverview.printVideo(youtubeVideo, counter + 1);
                /*Save video to database*/
                youtubeVideoRepository.InsertYoutubeVideo(youtubeVideo);

                /*Increase counter*/
                counter++;
            }
        }

        /*Collect video elemetns from page*/
        private ReadOnlyCollection<IWebElement> collectVideos()
        {
            /*Helper var to prevent stuck in infinite loop
             *  keep track of previous lenght
             *  if previous lenght == current lenght: collected all videos
            */
            int prevVids = 0;
            do
            {
                /*If list is initialized*/
                if(videos != null)
                {
                    /*Set previous lenght*/
                    prevVids = videos.Count;
                }
                /*Collect video elements*/
                videos = collectVideosPage();
                /*Scroll down*/
                scrollPage();
                /*Wait until new video's are loaded*/
                Thread.Sleep(1500);
            }
            /*stop loop:
             *   - amount of wanted videos reached
             *    *   - no videos left
            */
            while (videos.Count < amountVideos  && prevVids != videos.Count);

            return videos;
        }

        /*Collect video elements*/
        private ReadOnlyCollection<IWebElement> collectVideosPage()
        {
            /*selector*/
            By element = By.CssSelector("ytd-video-renderer");
            /*Search elements*/
            return driver.FindElements(element);
        }

        /*Get title in video element*/
        private string getTitle(IWebElement video)
        {
            /*Search title in video element*/
            IWebElement element = video.FindElement(By.CssSelector("#video-title"));
            /*Get text of found element*/
            return element.Text;
        }
        /*Get url in video element*/
        private string getUrl(IWebElement video)
        {
            /*Search url in video element*/
            IWebElement element = video.FindElement(By.CssSelector("#thumbnail"));
            /*Get href attribute which contains the url of found element*/
            return element.GetAttribute("href");
        }
        /*Get views in video element*/
        private string getViews(IWebElement video)
        {
            /*Search views in video element*/
            IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[1]"));
            /*Get text of found element*/
            return element.Text;
        }
        /*Get title in date element*/
        private string getDate(IWebElement video)
        {
            /*Search date in video element*/
            IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[2]"));
            /*Get text of found element*/
            return element.Text;
        }
        /*Get uploader in video element*/
        private string getUploader(IWebElement video)
        {
            /*Search uploader in video element*/
            IWebElement element = video.FindElement(By.XPath(".//*[@id='channel-name']/div/div/yt-formatted-string/a"));
            /*Get attribute textContent of found element*/
            return element.GetAttribute("textContent");
        }

        /*Check if element is a stream of video*/
        private bool checkStream(IWebElement video)
        {
            /*Try find date
              *succes: video 
              *error: stream
            */
            try
            {
                /*Try find date in element*/
                IWebElement element = video.FindElement(By.XPath(".//*[@id='metadata-line']/span[2]"));
                /*date found! ==> video*/
                return true;
            }
            catch
            {
                /*Date not found! ==> stream*/
                return false;
            }
        }
    }
}
