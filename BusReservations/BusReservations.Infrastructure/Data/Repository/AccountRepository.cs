using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
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
            _appDBContext.SaveChanges();
        }

        public void DeleteAccount(Guid id)
        {
            _appDBContext.Accounts.Remove(GetAccountById(id));
            _appDBContext.SaveChanges();
        }

        public Account GetAccountById(Guid id)
        {
            return _appDBContext.Accounts.FirstOrDefault(account => account.Id == id);
        }

        public IEnumerable<Account> GetAllAccounts(int pageIndex = 1)
        {
            return _appDBContext.Accounts.ToPagedList(pageIndex);
        }

        public void UpdateAccount(Guid id, Account newAccount)
        {
            var account = GetAccountById(id);
            if (account != null)
            {
                account = newAccount;
                _appDBContext.SaveChanges();
            }
        }
    }
}
