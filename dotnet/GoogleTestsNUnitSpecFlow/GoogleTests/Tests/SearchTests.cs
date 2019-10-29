using GoogleTests.Drivers;
using GoogleTests.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTests.Tests
{
    [TestFixture]
    class SearchTests
    {
        IWebDriver driver;
        SearchPageSteps searchPageSteps;
        SearchResultsPageSteps searchResultsPageSteps;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = Driver.GetDriver();
            searchPageSteps = new SearchPageSteps(driver);
            searchResultsPageSteps = new SearchResultsPageSteps(driver);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SearchEpamUpperCaseTest()
        {
            searchPageSteps.OpenSearchPage();
            searchPageSteps.Search("EPAM");
            Assert.AreEqual("https://careers.epam.by", searchResultsPageSteps.GetFoundSites().First());
        }

        [Test]
        public void SearchEpamLowerCaseTest()
        {
            searchPageSteps.OpenSearchPage();
            searchPageSteps.Search("epam");
            Assert.AreEqual("https://careers.epam.by", searchResultsPageSteps.GetFoundSites().First());
        }

        [Test]
        public void SearchEpamCamelCaseTest()
        {
            searchPageSteps.OpenSearchPage();
            searchPageSteps.Search("Epam");
            Assert.AreEqual("https://careers.epam.by", searchResultsPageSteps.GetFoundSites().First());
        }
    }
}
