using System;
using OpenQA.Selenium;

namespace MyElements.MyAttributes
{
    public class ByAttribute : Attribute
    {
        public string Selector { get; set; }

        public By By
        {
            get
            {
                if (this is ByIdAttribute)
                {
                    return By.Id(Selector);
                }
                else if (this is ByCssAttribute)
                {
                    return By.CssSelector(Selector);
                }
                else if (this is ByXPathAttribute)
                {
                    return By.XPath(Selector);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
