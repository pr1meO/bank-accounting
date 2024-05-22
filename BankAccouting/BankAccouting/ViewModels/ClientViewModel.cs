using BankAccouting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccouting.ViewModels
{
    public class ClientViewModel
    {
        private static readonly AppDbContext _appDbContext;

        static ClientViewModel() => _appDbContext = App.HostService.Services.GetRequiredService<AppDbContext>();

        public static List<Client> ClientToList() => _appDbContext.Clients.ToList();

        public static async Task AddClientToDbAsync(Client client)
        {
            await _appDbContext.Clients.AddAsync(client);
            await _appDbContext.SaveChangesAsync();
        }

        public static async Task EditClientToDbAsync(
            int index,
            string lastName,
            string firstName,
            string middleName,
            string phoneNumber,
            string gender)
        {
            var client = await _appDbContext.Clients.ElementAtAsync(index);

            (client.Lastname,
                client.Firstname,
                client.Middlename,
                client.PhoneNumber,
                client.Gender) = (lastName, firstName, middleName, phoneNumber, gender);

            await _appDbContext.SaveChangesAsync();
        }

        public static async Task DeleteClientToDbAsync(int index)
        {
            var client = await _appDbContext.Clients
                .Include(c => c.Accounts)
                .Include(c => c.Contracts)
                .ElementAtAsync(index);

            if (client.Accounts?.Count > 0)
                _appDbContext.Accounts.RemoveRange(client.Accounts);

            if (client.Contracts?.Count > 0)
                _appDbContext.Contracts.RemoveRange(client.Contracts);

            _appDbContext.Clients.Remove(client);
            await _appDbContext.SaveChangesAsync();
        }
    }
}