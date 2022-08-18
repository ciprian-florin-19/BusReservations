namespace BusReservations.Core.Domain.Factory
{
    public class CustomerFactory : IUserFactory
    {
        public User CreateUser()
        {
            return new User();
        }
    }
}
