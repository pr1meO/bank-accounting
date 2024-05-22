using Microsoft.EntityFrameworkCore;

namespace BankAccouting.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BankAccouting;Username=postgres;Password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Администратор" },
                new Role { Id = 2, Name = "Банкир"},
                new Role { Id = 3, Name = "Заведующий" });

            modelBuilder.Entity<Credential>().HasData(
                new Credential { Id = 1, Login = "admin", Password = "admin" });

            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, Lastname = "Каюда", Firstname = "Кирилл",
                Middlename = "Леонидович", PhoneNumber = "+7 (991) 750-42-65",
                Gender = "М", RoleId = 3, CredentialId = 1 });
        }
    }
}
