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

        public ProductItem()
        {
        }

        public ProductItem(string title, string creator, string price, string delivery, string url)
        {
            this.title = title;
            this.creator = creator;
            this.price = price;
            this.delivery = delivery;
            this.url = url;
        }
    }
}
