using PersonalAccounts2._0.DataAccess.Models;
using PersonalAccounts2._0.DTO;

namespace PersonalAccounts2._0.Service.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAllWithoutDetailsAsync();
        Task<List<AccountWithResidentsDTO>> GetAllWithDetailsAsync();
        Task<List<AccountDTO>> GetAllWithResidentsAsync();
        Task<AccountDTO> GetByIdAsync(int id);
        Task<List<AccountDTO>> GetAllByResidentNameAsync(string name);
        Task<List<AccountDTO>> GetAllByAddressAsync(string address);
        Task<List<AccountDTO>> GetAllByDateAsync(string date);
        Task<bool> AddAsync(AccountModel model);
        Task<AccountDTO> UpdateAsync(int Id, AccountModel model);
        Task<bool> DeleteAsync(int Id);
    }
}
