using Domain.Extensions;
using Domain.Interfaces;
using Domain.Models;
using Domain.UIMapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.PageLogic
{
    public class CreateAccountLogic : ICreateAccountLogic
    {
        private IWebDriver _driver;

        public CreateAccountLogic(IWebDriver driver)
        {
            _driver = driver;
        }

        public void CreateAccount(Person person)
        {
            _driver.FindElement(CreateAccountMapping.GenderMaleButton).Click();
            _driver.FindElement(CreateAccountMapping.FirstNameInput).ClearAndSendKeys(person.FirstName);
            _driver.FindElement(CreateAccountMapping.LastNameInput).ClearAndSendKeys(person.LastName);
            _driver.FindElement(CreateAccountMapping.PasswordInput).ClearAndSendKeys(person.Credentials.Password);

            var selectDay = new SelectElement(_driver.WaitForFindElement(CreateAccountMapping.DaySelect));
            selectDay.SelectByValue(person.DateOfBirth.Day.ToString());

            var selectMonth = new SelectElement(_driver.WaitForFindElement(CreateAccountMapping.MonthSelect));
            selectMonth.SelectByValue(person.DateOfBirth.Month.ToString());

            var selectYear = new SelectElement(_driver.WaitForFindElement(CreateAccountMapping.YearSelect));
            selectYear.SelectByValue(person.DateOfBirth.Year.ToString());

            var submitButton = _driver.WaitForFindElement(CreateAccountMapping.RegisterButton);
            _driver.ScrollAndClick(submitButton);
        }
    }
}
