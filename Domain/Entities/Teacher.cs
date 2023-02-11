using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher : Person
    {
       

        public Teacher(string firstName, string lastName, string personalNumber, string mail, DateTime dateOfBirth) : 
            base(firstName, lastName, personalNumber, mail, dateOfBirth)
        {
        }
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
