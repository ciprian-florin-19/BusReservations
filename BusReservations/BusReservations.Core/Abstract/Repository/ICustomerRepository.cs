using BusReservations.Core.Domain;

namespace BusReservations.Core.Abstract.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(Guid id);
        void UpdateCustomer(Guid id, Customer newCustomer);
        void DeleteCustomer(Guid id);
    }
}
