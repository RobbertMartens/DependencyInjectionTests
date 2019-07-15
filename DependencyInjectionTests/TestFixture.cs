using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using Domain.PageLogic;
using Domain.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DependencyInjectionTests
{
    public class TestFixture : IDisposable
    {
        public IServiceCollection ServiceCollection { get; set; }
        public Credentials Credentials { get; set; }

        public IWebDriver Driver;
        public string Dir = Directory.GetCurrentDirectory().Split("DependencyInjectionTests")[0] + "DependencyInjectionTests";
        public string Url = "https://techblog.polteq.com/testshop";

        public TestFixture()
        {
            Driver = new ChromeDriver(Dir);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);

            ServiceCollection = new ServiceCollection();
            ConfigureServices(ServiceCollection);

            var configFile = new ConfigFileReader();
            Credentials = configFile.GetCredentials();
        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        public void ConfigureServices(IServiceCollection serviceColletion)
        {
            IHeaderLogic headerLogic = new HeaderLogic(Driver);
            serviceColletion.AddSingleton(headerLogic);

            IAuthenticationLogic authenticationLogic = new AuthenticationLogic(Driver);
            serviceColletion.AddSingleton(authenticationLogic);

            ICreateAccountLogic createAccountLogic = new CreateAccountLogic(Driver);
            serviceColletion.AddSingleton(createAccountLogic);

            IMyAccountLogic myAccountLogic = new MyAccountLogic(Driver);
            serviceColletion.AddSingleton(myAccountLogic);
        }
    }
}
