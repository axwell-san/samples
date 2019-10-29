using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GoogleTests.Pages
{
    class SearchPage
    {
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement Input { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement SearchButton { get; set; }

        public SearchPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
