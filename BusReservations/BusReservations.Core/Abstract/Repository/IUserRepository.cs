using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        void CreateLocalBackup(string fileName);
        bool IsBackedUp { get; }
        void UpdateUser(User user);
        void DeleteUser(User user);
        void AddRange(IEnumerable<User> users);
    }
}