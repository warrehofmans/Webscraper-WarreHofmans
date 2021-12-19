using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webscraper_ConsoleApplication.DAL;
using Webscraper_ConsoleApplication.views;

namespace Webscraper_ConsoleApplication
{
    class Jobs : Scraper
    {

        private int jobCount;
        private JobAdvRepository jobAdvRepository = new JobAdvRepository();
       
        /*contructor
         * set searchterm (user input)
         * base url
         * base filter
         */
        public Jobs(string searchTerm)
        {
            this.searchTerm = searchTerm;
            this.url = "https://be.indeed.com/jobs?q=";
            this.filter = "&fromage=3";
        }

        /*Main function*/
        public void scrapeJobs()
        {
            /*set url
             * first make url
             */
            setUrl(makeUrl());
            /*scrape all jobs*/
            collectJobs();
        }

        /*scrape all jobs based on search criteria*/
        private void collectJobs()
        {
            /*Wait until page is loaded*/
            waitLoaded();
            /*Collect jobs from page*/
            var jobs = collectJobsPage();
            /*check if there are jobs found*/
            if(!checkResultEmpty(jobs)) {
                /*No jobs found*/
                Print.printNoResults();
                return;
            }
            /*Job founds*/
            else
            {
                /*Print header*/
                Print.printResults();
            }
            /*Save jobs to database*/
            saveJobs(jobs);
            /*Scroll page*/
            scrollPage();
           
            /*Check if there is a next page*/
            while (checkNext())
            {
                /*If next page, go to next page*/
                next();
                /*Wait until page loaded*/
                waitLoaded();
                
                /*check if popup comes up*/
                if (checkPopUp())
                {
                    /*If popup ==> close popup*/
                    closePopUP();
                }
                
                /*Collect jobs from new page*/
                jobs = collectJobsPage();
                /*Save jobs again*/
                saveJobs(jobs);
                /*Scroll page again*/
                scrollPage();
            }
        }

        /*Save and print jobs*/
        private void saveJobs(ReadOnlyCollection<IWebElement> jobs)
        {
            /*Loop over found job elements*/
            foreach (IWebElement job in jobs)
            {
                /*New job object*/
                JobAdv jobAdv = new JobAdv
                {
                    title = getTitle(job),
                    company = getCompany(job),
                    location = getLocation(job),
                    url = getLink(job)
                };

                /*Prin job advertiment information*/
                JobOverview.printJob(jobAdv, jobCount);
                /*Save job advertisement to database*/
                jobAdvRepository.InsertJobAdv(jobAdv);
                /*Increase counter*/
                jobCount++;
            }
        }

        /*collect all job elements on page*/
        private ReadOnlyCollection<IWebElement> collectJobsPage()
        {
            /*Selecteor to find element¨*/
            By element = By.CssSelector(".slider_container");
            /*search elements*/
            return driver.FindElements(element);
        }

        /*Get title from job element*/
        private string getTitle(IWebElement job)
        {
            /*Search in job element*/
            IWebElement element = job.FindElement(By.CssSelector(".jobTitle span:nth-child(2)"));
            /*Get text from element*/
            return element.Text;
        }

        private string getCompany(IWebElement job)
        {
            /*Search in job element*/
            IWebElement element = job.FindElement(By.CssSelector(".companyName"));
            /*Get text from element*/
            return element.Text;
        }

        private string getLocation(IWebElement job)
        {
            /*Search in job element*/
            IWebElement element = job.FindElement(By.CssSelector(".companyLocation"));
            /*Get text from element*/
            return element.Text;
        }

        private string getLink(IWebElement job)
        {
            /*Search in job element*/
            IWebElement element = job.FindElement(By.XPath("./.."));
            /*Get href attribute to retrieve url*/
            return element.GetAttribute("href");
        }

        /*Close popu*/
        private  void closePopUP()
        {
            /*Find and wait untile element clickable*/
            var element = FindElementClick(By.Id("popover-x"));
            /*Click popup*/
            element.Click();
   
        }

        /*Check if popup*/
        private bool checkPopUp()
        {
            /*Try find Popup
             *succes: popup present
             *erro: popup not present
            */

            try
            {  
                /*try find popup*/
                FindElementClick(By.Id("popover-x"));
                /*Found popup*/
                return true;
            }
            catch 
            {
                /*Error ==> no popup*/
                return false;
            }
        }

        /*Go to next page*/
        private void next()
        {
            /*selector*/
            By next = By.CssSelector("[aria-label='Volgende']");
            /*Find element and wait until clickable*/
            var element = FindElementClick(next);
            /*Click next page*/
            element.Click();
           
        }

        /*Check if there is a next page*/
        private bool checkNext()
        {
            /*Try find next page button
            *succes: button present
            *erro: button not present
           */
            try
            {
                /*try find button*/
                FindElementClick(By.CssSelector("[aria-label='Volgende']"));
                /*Button found*/
                return true;
            }
                catch
            {
                /*Error ==> button not found*/
                return false;
            }   
        }
    }
}
