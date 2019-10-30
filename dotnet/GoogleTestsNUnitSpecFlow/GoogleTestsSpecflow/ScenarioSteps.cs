using GoogleTests.Drivers;
using TechTalk.SpecFlow;

namespace GoogleTestsSpecflow
{
    [Binding]
    public class ScenarioSteps
    {
        public ScenarioContext ScenarioContext { get; }

        public ScenarioData ScenarioData { get; }

        public FeatureContext featureContext;

        public FeatureData FeatureData;

        public ScenarioSteps(ScenarioContext scenarioContext, FeatureData featureData)
        {
            ScenarioContext = scenarioContext;
            ScenarioData = new ScenarioData(scenarioContext);
            FeatureData = featureData;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioData.WebDriver = FeatureData.WebDriver ?? Driver.GetDriver();
            ScenarioContext.ScenarioContainer.RegisterInstanceAs(ScenarioData.WebDriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (FeatureData.WebDriver is null)
                ScenarioData.WebDriver?.Quit();
        }

        [Scope(Tag = "oneTimeDriver")]
        [BeforeFeature]
        public static void BeforeFeature(FeatureData featureData)
        {
            featureData.WebDriver = Driver.GetDriver();
        }
    }
}
