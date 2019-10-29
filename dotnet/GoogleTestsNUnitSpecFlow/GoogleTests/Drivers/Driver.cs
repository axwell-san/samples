using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleTests.Drivers
{
    public class Driver
    {
        static string Path;

        static Driver() => Path = System.IO.Path.GetFullPath
            (System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Binaries"));

        public static IWebDriver GetDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            var driver = new ChromeDriver(Path, options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
