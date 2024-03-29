using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace DependencyInjectionTests
{   [Collection("Login tests")]
    [Trait("UI Tests", "Login tests")]
    public class LoginTests : IClassFixture<TestFixture>, IDisposable
    {
        public IServiceProvider Services { get; set; }
        public IHeaderLogic HeaderLogic { get; set; }
        public IAuthenticationLogic AuthenticationLogic { get; set; }

        private TestFixture _testFixture;
        private ITestOutputHelper _output;

        public LoginTests(TestFixture testFixture, ITestOutputHelper output)
        {
            _testFixture = testFixture;
            _output = output;
            _testFixture.ConfigureServices(_testFixture.ServiceCollection);

            // Get required services
            Services = _testFixture.ServiceCollection.BuildServiceProvider();
            HeaderLogic = Services.GetService<IHeaderLogic>();
            AuthenticationLogic = Services.GetService<IAuthenticationLogic>();
        }

        public void Dispose()
        {
            _testFixture.Driver.Manage().Cookies.DeleteAllCookies();
            _testFixture.Driver.Navigate().GoToUrl(_testFixture.Url);
        }

        [Fact]
        public void LoginTest()
        {
            // Act
            HeaderLogic.GoToSignUp();
            AuthenticationLogic.Login(_testFixture.Credentials);

            // Assert
            Assert.True(HeaderLogic.IsLoggedIn(), "Logout button is not displayed!");
        }

        [Fact]
        public void LoginWrongUsernameTest()
        {
            // Assign
            var credentials = new Credentials
            {
                Username = "asdijewofo@mailinator.com",
                Password = _testFixture.Credentials.Password
            };

            // Act
            HeaderLogic.GoToSignUp();
            AuthenticationLogic.Login(credentials);

            // Assert
            Assert.False(HeaderLogic.IsLoggedIn());
        }

        [Fact]
        public void LoginWrongPasswordTest()
        {
            // Assign
            var credentials = new Credentials
            {
                Username = _testFixture.Credentials.Username,
                Password = "adiojgiorejiodf235"
            };

            // Act
            HeaderLogic.GoToSignUp();
            AuthenticationLogic.Login(credentials);

            // Assert
            Assert.False(HeaderLogic.IsLoggedIn());
        }
    }
}
