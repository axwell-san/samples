using OpenQA.Selenium;

namespace MyElements.MyElements
{
    public class MyInputElement : MyElement
    {
        public MyInputElement(By by, ISearchContext searchContext) : base(by, searchContext) { }

        public void Type(string value)
        {
            Do(() =>
            {
                WebElement.SendKeys(value);
            });
        }

        public void Clear()
        {
            Do(() =>
            {
                WebElement.Clear();
            });
        }

        public void ClearAndType(string value)
        {
            Do(() =>
            {
                Clear();
                Type(value);
            });
        }
    }
}
