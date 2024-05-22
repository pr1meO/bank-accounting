using BankAccouting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BankAccouting.ViewModels
{
    public class AccountViewModel
    {
        private static readonly AppDbContext _appDbContext;

        static AccountViewModel() => _appDbContext = App.HostService.Services.GetRequiredService<AppDbContext>();

        public static List<Account> AccountToList() => _appDbContext.Accounts
            .Include(a => a.Client)
            .ToList();

        public static async Task AddAccountToAndContractDbAsync(Account account, int accountNumber)
        {
            var clientId = await _appDbContext.Clients
                .Where(c => c.AccountNumber == accountNumber)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();

            if (clientId == 0)
            {
                MessageBox.Show("Клиент с таким номером счета не существует",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            account.ClientId = clientId;
            await AddContractToDbAsync(clientId);

            await _appDbContext.Accounts.AddAsync(account);
            await _appDbContext.SaveChangesAsync();
        }

        private static async Task AddContractToDbAsync(int clientId)
        {
            await ContractViewModel.AddContractToDbAsync(new Contract() 
            { 
                StaffId = MainWindow.Staff?.Id, 
                ClientId = clientId 
            });
        } 

        public static async Task EditAccountToDbAsync(int index, string balance, string typeAccount)
        {
            var account = await _appDbContext.Accounts.ElementAtAsync(index);

            (account.Balance,
                account.TypeAccount) = (Decimal.Parse(balance), typeAccount);

            await _appDbContext.SaveChangesAsync();
        }

        public static async Task DeleteAccountToDbAsync(int index)
        {
            var account = await _appDbContext.Accounts
                .Include(a => a.Client)
                .ElementAtAsync(index);

            _appDbContext.Accounts.Remove(account);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
