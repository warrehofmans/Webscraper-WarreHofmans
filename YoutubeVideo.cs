using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class YoutubeVideo
    {
        public string title { get; set; }
        public string url { get; set; }
        public string uploader { get; set; }
        public string views { get; set; } 
        public string date { get; set; }
        public int number { get; set; }


        public YoutubeVideo()
        {
        }

        public YoutubeVideo(string title, string url, string uploader, string views, string date, int number)
        {
            this.title = title;
            this.url = url;
            this.uploader = uploader;
            this.views = views;
            this.date = date;
            this.number = number;
        }

        
    }
}
