using Mapster;
using PersonalAccounts2._0.DataAccess.Models;
using PersonalAccounts2._0.DTO;
using PersonalAccounts2._0.Repository;
using PersonalAccounts2._0.Repository.Implementation;
using PersonalAccounts2._0.Service.Interfaces;
using System;

namespace PersonalAccounts2._0.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository staffRepository)
        {
            _accountRepository = staffRepository;
        }

        public async Task<List<AccountDTO>> GetAllWithoutDetailsAsync()
        {
            var accounts = await _accountRepository.ListAccountsAsync(a => a != null);
            return accounts.Adapt<List<AccountDTO>>();
        }

        public async Task<AccountDTO> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            return account.Adapt<AccountDTO>();
        }

        public async Task<List<AccountWithResidentsDTO>> GetAllWithDetailsAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return accounts.Adapt<List<AccountWithResidentsDTO>>();
        }

        public async Task<List<AccountDTO>> GetAllWithResidentsAsync()
        {
            var accountsWithResidents = await _accountRepository.ListAccountsAsync(a => a.AccountResidents.Any());

            return accountsWithResidents.Adapt<List<AccountDTO>>();
        }

        public async Task<List<AccountDTO>> GetAllByResidentNameAsync(string name)
        {
            var accounts = await _accountRepository.ListAccountsAsync(a => a.AccountResidents.Any(ar => ar.Resident.Name.Contains(name)));
            return accounts.Adapt<List<AccountDTO>>();
        }

        public async Task<List<AccountDTO>> GetAllByAddressAsync(string address)
        {
            var accounts = await _accountRepository.ListAccountsAsync(b => b.Address.Contains(address));
            return accounts.Adapt<List<AccountDTO>>();
        }

        public async Task<List<AccountDTO>> GetAllByDateAsync(string date)
        {
            var accounts = await _accountRepository.ListAccountsAsync(b => b.StartDate == DateOnly.Parse(date));
            return accounts.Adapt<List<AccountDTO>>();
        }

        public async Task<bool> AddAsync(AccountModel model)
        {
            var createdId = await _accountRepository.AddAsync(model);
            
            if (createdId > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<AccountDTO> UpdateAsync(int Id, AccountModel model)
        {
            var accountToUpdate = await _accountRepository.GetByIdAsync(Id);

            if (accountToUpdate != null)
            {
                accountToUpdate.AccountNumber = model.AccountNumber;
                accountToUpdate.StartDate = model.StartDate;
                accountToUpdate.EndDate = model.EndDate;
                accountToUpdate.Address = model.Address;
                accountToUpdate.RoomArea = model.RoomArea;
                await _accountRepository.Update(accountToUpdate);
            }
            return accountToUpdate.Adapt<AccountDTO>();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var accountToDelete = await _accountRepository.GetByIdAsync(Id);
            return await _accountRepository.DeleteAsync(accountToDelete);
        }
    }
}
