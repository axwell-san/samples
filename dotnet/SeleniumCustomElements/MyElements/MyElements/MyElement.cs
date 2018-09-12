using OpenQA.Selenium;
using System;

namespace MyElements.MyElements
{
    public abstract class MyElement
    {
        protected IWebElement WebElement
        {
            get
            {
                if (webElement == null)
                {
                    webElement = searchContext.FindElement(by);
                }

                return webElement;
            }
        }

        private By by;
        private ISearchContext searchContext;
        private IWebElement webElement;

        public MyElement(By by, ISearchContext searchContext)
        {
            this.by = by;
            this.searchContext = searchContext;
        }

        protected void Do(Action action)
        {
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    action.Invoke();
                }
                catch (StaleElementReferenceException)
                {
                    if (i == 3)
                    {
                        throw;
                    }

                    webElement = null;
                    continue;
                }
                catch (Exception)
                {
                    throw;
                }

                break;
            }
        }
    }
}
