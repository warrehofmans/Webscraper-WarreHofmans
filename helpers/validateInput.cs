using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.helpers
{
    class validateInput : Exists
    {

        public static bool checkFormat(string input)
        {
            if (checkOptions(input)) {
                return true;
            }
            if (!checkId(input))
            {
                Print.wrongFormat();
            }
            return false;
        }
        public static bool checkId (string input)
        {
            return int.TryParse(input, out _) && input != null;
        }

        private static bool checkOptions(string input)
        {
            return (input == "q") || (input == "a");
        }

        public static string validateVideoInput()
        {
            var input = Console.ReadLine();
            while(!checkFormat(input) && !(checkId(input) && videoExists(Int32.Parse(input)))){
                input = Console.ReadLine();
            }
            return input;
        }

        public static string validateJobInput()
        {
            var input = Console.ReadLine();
            while (!checkFormat(input) && !(checkId(input) && jobExists(Int32.Parse(input))))
            {
                input = Console.ReadLine();
            }
            return input;
        }

        public static string validateProductInput()
        {
            var input = Console.ReadLine();
            while (!checkFormat(input) && !(checkId(input) && productExists(Int32.Parse(input))))
            {
                input = Console.ReadLine();
            }
            return input;
        }


    }
}
