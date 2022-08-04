namespace BusReservations.Core.Domain.Factory
{
    public class AdminFactory : IUserFactory
    {
        public User CreateUser()
        {
            return new Administrator();
        }
    }
}
