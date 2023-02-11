using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Mail { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Person(string firstName, string lastName, string personalNumber, string mail, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            Mail = mail;
            DateOfBirth = dateOfBirth;
        }
    }
}
