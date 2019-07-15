using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UIMapping
{
    internal class MyAccountMapping
    {
        internal static By SuccesMessage => By.XPath("//* [@class='alert alert-success']");
    }
}
