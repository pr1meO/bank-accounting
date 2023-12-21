using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBankAccouting.Model;

namespace TestBankAccouting.Data
{
    public class ApplicationContextUsers : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source = UserData.db"); //поиск БД в СУБД

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Role)
                                       .WithOne(r => r.User)
                                       .HasForeignKey<User>(u => u.RoleID);
        }
    }
}
