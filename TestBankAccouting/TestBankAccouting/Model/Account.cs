using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Model
{
    public class Account
    {

        [Key]
        public int ID { get; set; }
        public double Balance { get; set; }
        public string TypeAccount { get; set; }

        [ForeignKey("ClientID")]
        public int ClientID { get; set; } //внешний ключ

        public Account(double balance, string typeAccount)
        {
            Balance = balance;
            TypeAccount = typeAccount;
        }
    }
}
