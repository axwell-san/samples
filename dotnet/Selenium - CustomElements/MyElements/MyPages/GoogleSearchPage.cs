using MyElements.MyElements;
using MyElements.MyAttributes;
using OpenQA.Selenium;

namespace MyElements.MyPages
{
    public class GoogleSearchPage : Page
    {
        [ById(Selector = "lst-ib")]
        public MyInputElement SearchField { get; set; }

        [ByCss(Selector = "input[value='Google Search']")]
        public MyButtonElement GoogleSearchButton { get; set; }

        [ByXPath(Selector = "//button[@value='Search']")]
        public MyButtonElement SearchButton { get; set; }

        public GoogleSearchPage(ISearchContext searchContext) : base(searchContext) { }
    }
}
