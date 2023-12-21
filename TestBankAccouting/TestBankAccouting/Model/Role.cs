using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Model
{
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string? NameRole { get; set; }
        public User? User { get; set; } //навигационное свойство
    }
}
