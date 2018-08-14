using MyElements.MyElements;
using MyElements.MyAttributes;
using OpenQA.Selenium;
using System.Reflection;

namespace MyElements.MyPages
{
    public static class PageExtensions
    {
        public static void Init(this Page page, ISearchContext searchContext)
        {
            var bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            foreach (var property in page.GetType().GetProperties(bindingFlags))
            {
                var byAttribute = property.GetCustomAttribute(typeof(ByAttribute), true) as ByAttribute;
                
                if (typeof(MyElement).IsAssignableFrom(property.PropertyType))
                {
                    var ctor = property.PropertyType.GetConstructor(new[] { typeof(By), typeof(ISearchContext) });
                    property.SetValue(page, ctor.Invoke(new object[] { byAttribute.By, searchContext }));
                }
            }
        }
    }
}
