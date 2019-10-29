using BoDi;
using GoogleTests.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GoogleTestsSpecflow.Hooks
{
    [Binding]
    public class Hooks
    {
        readonly IObjectContainer objectContainer;
        IWebDriver driver;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = Driver.GetDriver();
            objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
