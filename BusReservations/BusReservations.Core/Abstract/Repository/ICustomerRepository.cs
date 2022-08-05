using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
    }
}
