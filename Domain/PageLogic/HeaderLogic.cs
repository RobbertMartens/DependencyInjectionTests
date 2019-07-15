using Domain.Extensions;
using Domain.Interfaces;
using Domain.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pages
{
    public class HeaderLogic : IHeaderLogic
    {
        private readonly IWebDriver _driver;

        public HeaderLogic(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToSignUp()
        {
            var signUpButton = _driver.WaitForFindElement(HeaderMapping.SignUpButton);
            _driver.ScrollAndClick(signUpButton);
        }

        public void LogOut()
        {
            var logoutButton = _driver.WaitForFindElement(HeaderMapping.LogOutButton);
            logoutButton.Click();
        }

        public bool IsLoggedIn()
        {
            try
            {
                var logoutButton = _driver.WaitForFindElement(HeaderMapping.LogOutButton);
                return logoutButton.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
