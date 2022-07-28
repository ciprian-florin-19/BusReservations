using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Abstract.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomers();
    }
}
