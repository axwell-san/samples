using OpenQA.Selenium;

namespace MyElements.MyElements
{
    public class MyButtonElement : MyElement
    {
        public MyButtonElement(By by, ISearchContext searchContext) : base(by, searchContext) { }

        public void Press()
        {
            Do(() =>
            {
                WebElement.Click();
            });
        }
    }
}
