using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Webscraper_ConsoleApplication.model;

namespace Webscraper_ConsoleApplication
{
    class YoutubeVideo
    {
        public int id { get; set; }
        public VideoType type { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string uploader { get; set; }
        public string views { get; set; } 
        public string date { get; set; }



        public YoutubeVideo()
        {
        }

        public YoutubeVideo(VideoType type, string title, string url, string uploader, string views, string date)
        {
            this.title = title;
            this.url = url;
            this.uploader = uploader;
            this.views = views;
            this.date = date;
            this.type = type;
            
        }
    }
}
