﻿using BusReservations.Core;
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

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDBContext.Customers.ToPagedList();
        }
    }
}
