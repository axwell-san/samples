using GoogleTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace GoogleTests.Steps
{
    [Binding]
    class SearchResultsPageSteps
    {
        IWebDriver driver;
        SearchResultsPage searchResultsPage;

        public SearchResultsPageSteps(IWebDriver driver)
        {
            searchResultsPage = new SearchResultsPage(driver);
            this.driver = driver;
        }

        public IEnumerable<string> GetFoundSites()
        {
            Console.WriteLine("Get found sites");
            return searchResultsPage.Sites.Select(_ => _.Text);
        }

        [Then(@"first found site is (.*)")]
        public void VerifyFirstFoundSiteIs(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, GetFoundSites().First());
        }
    }
}
