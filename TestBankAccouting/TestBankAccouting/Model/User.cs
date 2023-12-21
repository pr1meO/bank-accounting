using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankAccouting.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public int? RoleID { get; set; } //внешний ключ
        public Role? Role { get; set; } //навигационное свойство
    }
}
