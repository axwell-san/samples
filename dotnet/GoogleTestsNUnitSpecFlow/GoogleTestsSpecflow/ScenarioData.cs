using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace GoogleTestsSpecflow
{
    public class ScenarioData
    {
        private readonly ScenarioContext _scenarioContext;

        public ScenarioData(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver WebDriver
        {
            get => _scenarioContext.Get<IWebDriver>(nameof(WebDriver));
            set => _scenarioContext.Set(value, nameof(WebDriver));
        }
    }
}
