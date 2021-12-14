using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.model
{
    class ProductItem
    {

        public int id { get; set; }
        public string title { get; set; }
        public string creator { get; set; }
        public string price { get; set; }

        public string delivery { get; set; }
        public string url { get; set; }
    }
}
