using System;


namespace Webscraper_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Scraper scraper = new Scraper();
            while (true)
            {
                Print.StartScreen();

                var choice = Console.ReadLine();

                if (choice.ToLower() == "1")
                {

                    Console.WriteLine("Search?");
                    string searchTerm = Console.ReadLine();
                    Youtube youtube = new Youtube(searchTerm);
                    youtube.scrapeYoutube();

                }
            }
            

            
            
        }
    }
}
