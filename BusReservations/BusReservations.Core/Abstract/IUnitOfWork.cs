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
    }
}
