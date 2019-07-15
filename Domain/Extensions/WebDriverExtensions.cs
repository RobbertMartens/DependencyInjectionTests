using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Domain.Extensions
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Repeated searches for an element until it is visible. If visibility is ignored, searches until element
        /// is not null
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="ignoreDisplayed">By default, an element must be displayed on page. 
        /// Set to true to search for hidden elements</param>
        /// <returns></returns>
        public static IWebElement WaitForFindElement(this IWebDriver driver, By by, bool ignoreDisplayed = false)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return wait.Until(webDriver =>
            {
                if (ignoreDisplayed == false)
                {
                    if (webDriver.FindElement(by).Displayed)
                    {
                        return webDriver.FindElement(by);
                    }
                    return null;
                }
                else
                {
                    if (webDriver.FindElement(by) != null)
                    {
                        return webDriver.FindElement(by);
                    }
                    return null;
                }
            });
        }

        /// <summary>
        /// Repeated searches for elements to return a ReadOnlyCollection of web elements.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> WaitForFindElements(this IWebDriver driver, By by)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return wait.Until(webDriver =>
            {
                if (webDriver.FindElements(by).Count > 0)
                {
                    return webDriver.FindElements(by);
                }
                return null;
            });
        }

        public static void ScrollAndClick(this IWebDriver driver, IWebElement el)
        {
            var javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            el.Click();
        }
    }
}
