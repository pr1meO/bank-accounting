using BankAccouting.Generate;
using BankAccouting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BankAccouting.ViewModels
{
    public static class StaffViewModel
    {
        private static readonly AppDbContext _appDbContext;
        private const int lengthPassword = 6;

        static StaffViewModel() => _appDbContext = App.HostService.Services.GetRequiredService<AppDbContext>();

        public static List<Staff> StaffToList() => _appDbContext.Staffs
            .Include(s => s.Role)
            .ToList();

        public static async Task AddStaffToDbAsync(Staff staff)
        {
            var credential = await AddCredentialToDbAsync(staff.Lastname!);
            staff.CredentialId = credential.Id;

            await _appDbContext.Staffs.AddAsync(staff);
            await _appDbContext.SaveChangesAsync();
        }

        private static async Task<Credential> AddCredentialToDbAsync(string lastName)
        {
            Credential credential = new Credential 
            { 
                Login = $"Staff{lastName}", 
                Password = Password.GeneratePassword(lengthPassword)
            };

            await _appDbContext.Credentials.AddAsync(credential);
            await _appDbContext.SaveChangesAsync();

            return credential;
        }

        public static async Task EditStaffToDbAsync(
            int index,
            string lastName,
            string firstName,
            string middleName,
            string phoneNumber,
            string gender,
            int role)
        {
            var staff = await _appDbContext.Staffs.ElementAtAsync(index);

            (staff.Lastname,
                staff.Firstname,
                staff.Middlename,
                staff.PhoneNumber,
                staff.Gender,
                staff.RoleId) = (lastName, firstName, middleName, phoneNumber, gender, ++role);

            await _appDbContext.SaveChangesAsync();
        }

        public static async Task DeleteStaffToDbAsync(int index)
        {
            var staff = await _appDbContext.Staffs
                .Include (s => s.Credential)
                .ElementAtAsync(index);

            _appDbContext.Credentials.Remove(staff.Credential!);
            _appDbContext.Staffs.Remove(staff);
            await _appDbContext.SaveChangesAsync();                
        }
    }
}
