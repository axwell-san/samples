using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace GoogleTests.Pages
{
    class SearchResultsPage
    {
        [FindsBy(How = How.TagName, Using = "cite")]
        public IList<IWebElement> Sites { get; set; }

        public SearchResultsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
