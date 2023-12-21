using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.Model;

namespace TestBankAccouting.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = DataBankAccouting.db"); //поиск БД в СУБД
    }
}
