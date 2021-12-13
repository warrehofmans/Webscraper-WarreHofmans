using System;
using System.Collections.Generic;
using System.Text;

namespace Webscraper_ConsoleApplication.views
{
    class JobOverview
    {

        public static void printJob(JobAdv job, int count)
        {
            Console.WriteLine("******* Job " + count + " *******");
            Console.WriteLine("Job Title: " + job.title);
            Console.WriteLine("Job Company: " + job.company);
            Console.WriteLine("Job Location: " + job.location);
            Console.WriteLine("Job URL: " + job.url);
            Console.WriteLine("\n");
        }

        public static void printJob(JobAdv job)
        {
            Console.WriteLine(job.id + ")");
            Console.WriteLine("Job Title: " + job.title);
            Console.WriteLine("Job Company: " + job.company);
            Console.WriteLine("Job Location: " + job.location);
            Console.WriteLine("Job URL: " + job.url);
            Console.WriteLine("\n");
        }

        public static void printJobOverview()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Delete a job advertisement? - delete all: a - exit: q");
         
        }

        public static void NoJobsFound()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("You have no job advertisements saved");
            
        }

        public static void Header(int count)
        {
           Console.WriteLine("You have " + count + " job advertisements saved!");
           Console.WriteLine("-----------------------------------------------------");

        }
    }
}
