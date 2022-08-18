using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        IEnumerable<Account> GetAllAccounts(int pageIndex = 1);
        Account GetAccountById(Guid id);
        void UpdateAccount(Guid id, Account newAccount);
        void DeleteAccount(Guid id);
    }
}
