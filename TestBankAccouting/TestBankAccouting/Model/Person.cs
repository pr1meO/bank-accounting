using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Model
{
    abstract public class Person
    {
        abstract public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string NumberPhone { get; set; }

        public Person(string lastName, string firstName, string middleName, string gender, string numberPhone)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Gender = gender;
            NumberPhone = numberPhone;
        }
    }
}
