using System;
using OpenQA.Selenium;

namespace GoogleTestsSpecflow
{
    public class FeatureData : IDisposable
    {
        public IWebDriver WebDriver;

        public void Dispose()
        {
            WebDriver?.Quit();
        }
    }
}
