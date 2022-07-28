using BusReservations.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Abstract
{
    public interface IUnitOfWork
    {
        IBusRepository BusRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        ICustomerRepository CustomerRepository { get; set; }
        IReservationRepository ReservationRepository { get; set; }
    }
}
