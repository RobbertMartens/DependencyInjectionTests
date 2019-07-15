using System;

namespace Domain.Models
{
    public class Person
    {
        public bool IsMale { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Credentials Credentials { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
