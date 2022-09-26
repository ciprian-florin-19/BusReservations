using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<IEnumerable<User>> GetAllUsers(int index);
        Task<User> GetUserById(Guid id);
        void CreateLocalBackup(string fileName);
        bool IsBackedUp { get; }
        void UpdateUser(User user);
        void DeleteUser(User user);
        void AddRange(IEnumerable<User> users);
        Task<IEnumerable<User>> GetUsersByStatus(Status status, int index);
        Task<User> DoesUserExist(User user);
    }
}