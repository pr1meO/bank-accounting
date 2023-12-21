using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.ViewModel;

namespace TestBankAccouting.Model
{
    public class Staff : Person
    {
        [Key]
        public override int ID { get; set; }
        public string Post { get; set; }

        public Staff(string lastName, string firstName, string middleName, string gender, string numberPhone, string post)
            : base(lastName, firstName, middleName, gender, numberPhone)
        {
            Post = post;
        }
    }
}
