using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webscraper_ConsoleApplication.DAL;

namespace Webscraper_ConsoleApplication
{
    class Jobs : Scraper
    {

        private int jobCount;
        private JobAdvRepository jobAdvRepository = new JobAdvRepository();
       
        public Jobs(string searchTerm)
        {
            this.searchTerm = searchTerm;
            this.url = "https://be.indeed.com/jobs?q=";
            this.filter = "&fromage=3";
        }

        public void searchJobs()
        {
            setUrl(makeUrl());
            collectJobs();
        }

        private void collectJobs()
        {
            var count = 1;
            scrollPage();
            var jobs = collectJobsPage();
            if(!checkResultEmpty(jobs)) {
                Print.printNoResults();
                return;
                }
            saveJobs(jobs);
            while (checkNext())
            {
                next();
                if (count == 1)
                {
                    closePopUP();
                }
                scrollPage();
                jobs = collectJobsPage();
                saveJobs(jobs);
                count++;
            }
        }

        private void saveJobs(ReadOnlyCollection<IWebElement> jobs)
        {
            foreach (IWebElement job in jobs)
            {
                JobAdv jobAdv = new JobAdv
                {
                    title = getTitle(job),
                    company = getCompany(job),
                    location = getLocation(job),
                    url = getLink(job)
                };

                Print.printJob(jobAdv, jobCount);
                jobAdvRepository.InsertJobAdv(jobAdv);
                jobCount++;
            }
        }
        private ReadOnlyCollection<IWebElement> collectJobsPage()
        {
            By element = By.CssSelector(".slider_container");
            return driver.FindElements(element);
        }

        private string getTitle(IWebElement job)
        {
            IWebElement element = job.FindElement(By.CssSelector(".jobTitle span:nth-child(2)"));
            return element.Text;
        }

        private string getCompany(IWebElement job)
        {
            IWebElement element = job.FindElement(By.CssSelector(".companyName"));
            return element.Text;
        }

        private string getLocation(IWebElement job)
        {
            IWebElement element = job.FindElement(By.CssSelector(".companyLocation"));
            return element.Text;
        }

        private string getLink(IWebElement job)
        {
            IWebElement element = job.FindElement(By.XPath("./.."));
            return element.GetAttribute("href");
        }


        private  void closePopUP()
        {
            var element = FindElement(By.Id("popover-x"));
            element.Click();
   
        }

        private void next()
        {
            By next = By.CssSelector("[aria-label='Volgende']");
            var element = FindElement(next);
            element.Click();
        }

        private bool checkNext()
        {
            try
            {
                FindElement(By.CssSelector("[aria-label='Volgende']"));
                return true;
            }
                catch(Exception e)
            {
                return false;
            }   
        }
    }
}
