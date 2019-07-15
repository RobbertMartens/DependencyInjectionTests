using Domain.Extensions;
using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using Domain.UIMapping;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.PageLogic
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        private readonly IWebDriver _driver;

        public AuthenticationLogic(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToCreateAccount(Person person)
        {
            var emailField = _driver.WaitForFindElement(AuthenticationMapping.CreateEmailField);
            emailField.Clear();
            emailField.SendKeys(person.Credentials.Username);

            var submitButton = _driver.WaitForFindElement(AuthenticationMapping.CreateSubmitButton);
            _driver.ScrollAndClick(submitButton);
        }

        public void Login(Credentials credentials)
        {
            var usernameField = _driver.WaitForFindElement(AuthenticationMapping.LoginEmailField);
            usernameField.Clear();
            usernameField.SendKeys(credentials.Username);

            var passwordField = _driver.WaitForFindElement(AuthenticationMapping.PasswordField);
            passwordField.Clear();
            passwordField.SendKeys(credentials.Password);

            var submitButton = _driver.WaitForFindElement(AuthenticationMapping.LoginSubmitButton);
            _driver.ScrollAndClick(submitButton);
        }
    }
}
