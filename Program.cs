using System;


namespace Webscraper_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            Url url = new Url();
            Print.StartScreen();

            var choice = Console.ReadLine();

            if( choice.ToLower() == "1")
            {
              Console.WriteLine("Search?");
              var src = url.youtubeSearch(Console.ReadLine());
                scraper.setUrl(src);

            }

            
            
        }
    }
}
