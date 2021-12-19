using System;
using System.Collections.Generic;
using System.Text;
using Webscraper_ConsoleApplication.service;

namespace Webscraper_ConsoleApplication.helpers
{
    class FilterTranslation
    {
        /*check if list of filters has been initialized*/
        public static bool initialized = false;
        /*map filters input number with key of filter dictionnairry*/
        public static Dictionary<int, string> translationFilters = new Dictionary<int, string>();

        /*Convert input int to a valid filter*/
        public static string translate(string intKey)
        {
            /*retrieve key for filter dictionnaire of translation dictionanire*/
          var termKey = translationFilters[Int32.Parse(intKey)];
            /*return filter from filter dictionnaire*/
           return Product.avaibleFilters[termKey]; 

        }
    }
}
