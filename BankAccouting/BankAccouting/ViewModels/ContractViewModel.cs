using BankAccouting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccouting.ViewModels
{
    public static class ContractViewModel
    {
        private static readonly AppDbContext _appDbContext;

        static ContractViewModel() => _appDbContext = App.HostService.Services.GetRequiredService<AppDbContext>();

        public static List<Contract> ContractToList() => _appDbContext.Contracts
            .Include(c => c.Staff)
            .Include(c => c.Client)
            .ToList();

        public static async Task AddContractToDbAsync(Contract contract)
        {
            await _appDbContext.Contracts.AddAsync(contract);
            await _appDbContext.SaveChangesAsync();
        }

        public static async Task DeleteContractToDbAsync(int index)
        {
            var contract = await _appDbContext.Contracts
                .ElementAtAsync(index);

            _appDbContext.Contracts.Remove(contract);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
