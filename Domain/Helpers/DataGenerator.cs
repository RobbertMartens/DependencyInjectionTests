using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Helpers
{
    public static class DataGenerator
    {
        public static Person GeneratePerson()
        {
            return new Person
            {
                IsMale = true,
                FirstName = GenerateRandomString(8),
                LastName = GenerateRandomString(8),
                Credentials = GenerateCredentials(),
                DateOfBirth = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day)
            };
        }

        public static Credentials GenerateCredentials()
        {
            return new Credentials
            {
                Username = GenerateRandomString(8) + "@mailinator.com",
                Password = "ISeeYou!!"
            };
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }
    }
}
