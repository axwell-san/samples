using GoogleTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace GoogleTests.Steps
{
    [Binding]
    public class SearchPageSteps
    {
        IWebDriver driver;
        SearchPage searchPage;

        public SearchPageSteps(IWebDriver driver)
        {
            searchPage = new SearchPage(driver);
            this.driver = driver;
        }

        [Given(@"I opened Google Search page")]
        public void OpenSearchPage()
        {
            Console.WriteLine("Open https://www.google.com/");
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"I search for (.*)")]
        public void Search(string text)
        {
            Console.WriteLine($"Input '{text}' for search and click search button");
            searchPage.Input.SendKeys(text);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(_ => searchPage.SearchButton.Displayed);
            searchPage.SearchButton.Click();
        }
    }
}
