using Domain.Helpers;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DependencyInjectionTests
{
    [Collection("Register tests")]
    [Trait("UI Tests", "Register tests")]
    public class RegisterTests : IClassFixture<TestFixture>, IDisposable
    {
        public IServiceProvider Services { get; set; }
        public IHeaderLogic HeaderLogic { get; set; }
        public IAuthenticationLogic AuthenticationLogic { get; set; }
        public ICreateAccountLogic CreateAccountLogic { get; set; }
        public IMyAccountLogic MyAccountLogic { get; set; }

        private TestFixture _testFixture;
        private ITestOutputHelper _output;

        public RegisterTests(TestFixture testFixture, ITestOutputHelper output)
        {
            _testFixture = testFixture;
            _output = output;
            _testFixture.ConfigureServices(_testFixture.ServiceCollection);

            // Get required services
            Services = _testFixture.ServiceCollection.BuildServiceProvider();
            HeaderLogic = Services.GetService<IHeaderLogic>();
            AuthenticationLogic = Services.GetService<IAuthenticationLogic>();
            CreateAccountLogic = Services.GetService<ICreateAccountLogic>();
            MyAccountLogic = Services.GetService<IMyAccountLogic>();
        }

        public void Dispose()
        {
            _testFixture.Driver.Manage().Cookies.DeleteAllCookies();
            _testFixture.Driver.Navigate().GoToUrl(_testFixture.Url);
        }

        [Fact]
        public void RegisterTest()
        {
            // Assign
            var person = DataGenerator.GeneratePerson();

            // Act
            HeaderLogic.GoToSignUp();
            AuthenticationLogic.GoToCreateAccount(person);
            CreateAccountLogic.CreateAccount(person);

            // Assert
            Assert.True(MyAccountLogic.IsSucces(), "Succes message not is displayed!");
        }
    }
}
