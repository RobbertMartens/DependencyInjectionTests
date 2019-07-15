using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class WebElementExtensions
    {
        public static void ClearAndSendKeys(this IWebElement el, string keys)
        {
            el.Clear();
            el.SendKeys(keys);
        }
    }
}
