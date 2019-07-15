using OpenQA.Selenium;

namespace Domain.UIMapping
{
    internal class CreateAccountMapping
    {
        internal static By GenderMaleButton => By.Id("id_gender1");
        internal static By FirstNameInput => By.Id("customer_firstname");
        internal static By LastNameInput => By.Id("customer_lastname");
        internal static By EmailInput => By.Id("email");
        internal static By PasswordInput => By.Id("passwd");
        internal static By DaySelect => By.Id("days");
        internal static By MonthSelect => By.Id("months");
        internal static By YearSelect => By.Id("years");
        internal static By RegisterButton => By.Id("submitAccount");
    }
}
