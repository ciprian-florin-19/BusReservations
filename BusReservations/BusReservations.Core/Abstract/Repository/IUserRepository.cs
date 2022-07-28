using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}
