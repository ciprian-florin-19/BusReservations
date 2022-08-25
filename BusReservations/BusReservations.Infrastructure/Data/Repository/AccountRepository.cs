using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext _appDBContext;

        public AccountRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddAccount(Account account)
        {
            _appDBContext.Accounts.Add(account);
        }

        public void AddRange(IEnumerable<Account> accounts)
        {
            _appDBContext.Accounts.AddRange(accounts);
        }

        public void DeleteAccount(Account account)
        {
            _appDBContext.Accounts.Remove(account);
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            var account = await _appDBContext.Accounts.SingleOrDefaultAsync(account => account.Id == id);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts(int pageIndex = 1)
        {
            return await _appDBContext.Accounts.ToPagedListAsync(pageIndex);
        }

        public void UpdateAccount(Account account)
        {
            _appDBContext.Update(account);
        }
    }
}
