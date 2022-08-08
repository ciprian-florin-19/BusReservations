using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

namespace BusReservations.Infrastructure.Data.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _appDBContext;

        public CustomerRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public void AddCustomer(Customer customer)
        {
            _appDBContext.Customers.Add(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            _appDBContext.Customers.Remove(GetCustomerById(id));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDBContext.Customers.ToPagedList();
        }

        public Customer GetCustomerById(Guid id)
        {
            return _appDBContext.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public void UpdateCustomer(Guid id, Customer newCustomer)
        {
            var index = _appDBContext.Customers.IndexOf(GetCustomerById(id));
            if (index != -1)
                _appDBContext.Customers[index] = newCustomer;
        }
    }
}
