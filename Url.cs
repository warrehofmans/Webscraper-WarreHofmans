using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class Url
    {
        public string youtube { get; }
        public string jobs { get; }



        public Url()
        {
            this.youtube = "https://www.youtube.com/results?search_query=";
            this.jobs = jobs;
        }

        public string youtubeSearch(string term)
        {
            return youtube + term;
        }
    }
}
