using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        private IBusRepository? _busRepository;
        
        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBusRepository BusRepository 
        {    
            get 
            {
                if (_busRepository == null)
                    _busRepository = new BusRepository(_dbContext);

                return _busRepository;
            }
            set 
            {
                _busRepository = value;
            } 
        }
    }
}
