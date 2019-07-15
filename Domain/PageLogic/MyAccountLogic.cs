using Domain.Extensions;
using Domain.Interfaces;
using Domain.UIMapping;
using OpenQA.Selenium;
using System;

namespace Domain.PageLogic
{
    public class MyAccountLogic : IMyAccountLogic
    {
        private IWebDriver _driver;

        public MyAccountLogic(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsSucces()
        {
            try
            {
                var succesMessage = _driver.WaitForFindElement(MyAccountMapping.SuccesMessage);
                return succesMessage.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
