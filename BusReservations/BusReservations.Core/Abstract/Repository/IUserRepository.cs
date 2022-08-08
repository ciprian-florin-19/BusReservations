using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
        void CreateLocalBackup(string fileName);
        bool IsBackedUp { get; }
        void UpdateUser(Guid id, User newUser);
        void DeleteUser(Guid id);
    }
}