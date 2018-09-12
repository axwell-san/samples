using MyElements.MyPages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyElements
{ 
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test()
        {
            driver.Navigate().GoToUrl("https://www.google.com/?hl=en");
            GoogleSearchPage page = new GoogleSearchPage(driver);
            page.SearchField.Type("EPAM");
            page.GoogleSearchButton.Press();
            page.SearchField.ClearAndType("GOOGLE");
            page.SearchButton.Press();
        }
    }
}
