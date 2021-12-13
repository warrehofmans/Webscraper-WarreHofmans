using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication
{
    class JobAdv { 


        public int id { get; set; }
        public string title { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string url { get; set; }

        public JobAdv()
        {
        }

        public JobAdv(string title, string company, string location, string url)
        {
           
            this.title = title;
            this.company = company;
            this.location = location;
            this.url = url;
        }
    }
}
