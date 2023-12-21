using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Model
{
    public class Client : Person
    {
        private static int countAccountNumber = 22022018;

        [Key]
        public override int ID { get; set; }
        public int AccountNumber { get; set; }

        public Client(string lastName, string firstName, string middleName, string gender, string numberPhone)
            : base(lastName, firstName, middleName, gender, numberPhone)
        {
            AccountNumber = countAccountNumber++;
        }
    }
}
