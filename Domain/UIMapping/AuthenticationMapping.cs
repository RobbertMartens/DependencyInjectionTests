using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.UIMapping
{
    internal class AuthenticationMapping
    {
        internal static By CreateEmailField => By.Id("email_create");
        internal static By CreateSubmitButton => By.Id("SubmitCreate");
        internal static By LoginEmailField => By.Id("email");
        internal static By PasswordField => By.Id("passwd");
        internal static By LoginSubmitButton => By.Id("SubmitLogin");
    }
}
