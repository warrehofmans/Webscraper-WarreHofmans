using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class YoutubeVideo : IEquatable<YoutubeVideo>
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string uploader { get; set; }
        public string views { get; set; } 
        public string date { get; set; }


        public YoutubeVideo()
        {
        }

        public YoutubeVideo(string title, string url, string uploader, string views, string date)
        {
            this.title = title;
            this.url = url;
            this.uploader = uploader;
            this.views = views;
            this.date = date;
            
        }

     
        public bool Equals( YoutubeVideo other)
        {
            return url == other.url;
        }
    }
}
