using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.views
{
    class JobOverview
    {
        /*Print: search header*/
        public static void printSearch()
        {
            Console.Clear();
            Console.WriteLine("What term would you like to search job advertisements with?");
        }

        /*Print: job - in search*/
        public static void printJob(JobAdv job, int count)
        {
            Console.WriteLine("******* Job " + count + " *******");
            Console.WriteLine("Job Title: " + job.title);
            Console.WriteLine("Job Company: " + job.company);
            Console.WriteLine("Job Location: " + job.location);
            Console.WriteLine("Job URL: " + job.url);
            Console.WriteLine("\n");
        }

        /*Print: job - in overview*/
        public static void printJob(JobAdv job)
        {
            Console.WriteLine(job.id + ")");
            Console.WriteLine("Job Title: " + job.title);
            Console.WriteLine("Job Company: " + job.company);
            Console.WriteLine("Job Location: " + job.location);
            Console.WriteLine("Job URL: " + job.url);
            Console.WriteLine("\n");
        }

        /*Print: job overview menu*/
        public static void printJobOverview()
        {
        
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Delete a job advertisement? - delete all: a - exit: q");
         
        }

        /*Print: no job founds*/
        public static void NoJobsFound()
        {
            Console.Clear();
            Console.WriteLine("You have no job advertisements saved");
            
        }

        /*Print: overview job header*/
        public static void Header(int count)
        {
            Console.Clear();
            Console.WriteLine("You have " + count + " job advertisements saved!");
           Console.WriteLine("-----------------------------------------------------");

        }
        
    }
}
