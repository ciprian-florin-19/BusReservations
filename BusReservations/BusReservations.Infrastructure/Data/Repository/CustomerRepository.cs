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
            _appDBContext.SaveChanges();
        }

        public void DeleteCustomer(Guid id)
        {
            _appDBContext.Customers.Remove(GetCustomerById(id));
            _appDBContext.SaveChanges();
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
            var customer = GetCustomerById(id);
            if (customer != null)
            {
                customer = newCustomer;
                _appDBContext.SaveChanges();
            }
        }
    }
}
