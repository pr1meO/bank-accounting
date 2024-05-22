using BankAccouting.Models;
using BankAccouting.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BankAccouting.ViewModels
{
    public class LoginViewModel
    {
        private readonly AppDbContext _appDbContext;
        private const int blockRole = 2;

        public LoginViewModel()
        {
            _appDbContext = App.HostService.Services.GetRequiredService<AppDbContext>();
        }

        public async Task SearchCredentialToDbAsync(string login, string password, LoginWindow loginWindow)
        {
            var credentialId = await _appDbContext.Credentials
                .Where(c => c.Login == login && c.Password == password)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            if (credentialId != 0)
            {
                var staff = await _appDbContext.Staffs
                    .Include(s => s.Role)
                    .FirstAsync(s => s.CredentialId == credentialId);

                OpenMainWindow(staff, loginWindow);
            }
            else MessageBox.Show("Неправильный логин или пароль",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        private void OpenMainWindow(Staff staff, LoginWindow loginWindow)
        {
            if (staff.RoleId != blockRole)
            {
                var mainWindow = new MainWindow(staff);
                mainWindow.Show();
                loginWindow.Close();
            }
            else MessageBox.Show("Не соответствуют права доступа для входа",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
}