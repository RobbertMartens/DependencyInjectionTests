using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UIMapping
{
    internal class HeaderMapping
    {
        internal static By SignUpButton => By.XPath("//* [@class='login']");
        internal static By LogOutButton => By.XPath("//* [@class='logout']");
    }
}
