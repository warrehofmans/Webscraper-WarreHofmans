using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.service;

namespace Webscraper_ConsoleApplication.helpers
{
    class FilterTranslation
    {
        public static bool initialized = false;
        public static Dictionary<int, string> translationFilters = new Dictionary<int, string>();

        public static string translate(string intKey)
        {
          var termKey = translationFilters[Int32.Parse(intKey)];
           return Product.avaibleFilters[termKey]; 

        }
    }
}
