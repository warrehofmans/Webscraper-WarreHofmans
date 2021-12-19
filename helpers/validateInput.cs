using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.helpers
{
    class validateInput : Exists
    {

        /*check if input has the correct format*
         * checkoptions: true
         * string: false
         */
        public static bool checkFormat(string input)
        {
            /*q or a*/
            if (checkOptions(input)) {
                return true;
            }
            /*normal string*/
            if (!checkId(input))
            {
                /*Ask for other format*/
                Print.wrongFormat();
            }
            return false;
        }

        /*Check if input string is an integer and not null*/
        /*
         * input = string
         * tryParse ==> true: string can be parsed to int
         */
        public static bool checkId (string input)
        {
            return int.TryParse(input, out _) && input != null;
        }

        /*Check if input is a or q
         * a ==> delete all
         * q ==> quite menu */
        private static bool checkOptions(string input)
        {
            return (input == "q") || (input == "a");
        }


        /*Check format of video input
         * checkformat: true
         * checkId + exist: true
         */
        public static string validateVideoInput()
        {
            /*ask user input*/
            var input = Console.ReadLine();
            /*validate input
             *1ste check: q or a
             *2de check: 
             *       - integer
             *       - id of existing video
             */
            while(!checkFormat(input) && !(checkId(input) && videoExists(Int32.Parse(input)))){
                /*not validated! ==> ask new input*/
                input = Console.ReadLine();
            }
            /*valaidated! ==> return input*/
            return input;
        }

        /*Check format of job input
       * checkformat: true
       * checkId + exist: true
       */
        public static string validateJobInput()
        {
            var input = Console.ReadLine();
            /*validate input
           *1ste check: q or a
           *2de check: 
           *       - integer
           *       - id of existing product
           */
            while (!checkFormat(input) && !(checkId(input) && jobExists(Int32.Parse(input))))
            {
                /*not validated! ==> ask new input*/
                input = Console.ReadLine();
            }
            /*valaidated! ==> return input*/
            return input;
        }


        /*Check format of product input
       * checkformat: true
       * checkId + exist: true
       */
        public static string validateProductInput()
        {
            var input = Console.ReadLine();
            /*validate input
           *1ste check: q or a
           *2de check: 
           *       - integer
           *       - id of existing product
           */
            while (!checkFormat(input) && !(checkId(input) && productExists(Int32.Parse(input))))
            {
                /*not validated! ==> ask new input*/
                input = Console.ReadLine();
            }
            /*valaidated! ==> return input*/
            return input;
        }


    }
}
