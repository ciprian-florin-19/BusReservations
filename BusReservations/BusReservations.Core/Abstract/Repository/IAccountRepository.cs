using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        Task<IEnumerable<Account>> GetAllAccounts(int pageIndex = 1);
        Task<Account> GetAccountById(Guid id);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
