using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Infrastructure.Data.Repository;

namespace BusReservations.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
        private IBusRepository? _busRepository;
        private IUserRepository? _userRepository;
        private ICustomerRepository? _customerRepository;
        private IReservationRepository? _reservationRepository;
        private IDrivenRouteRepository? _routeRepository;

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

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_dbContext);

                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_dbContext);

                return _customerRepository;
            }
            set
            {
                _customerRepository = value;
            }
        }

        public IReservationRepository ReservationRepository
        {
            get
            {
                if (_reservationRepository == null)
                    _reservationRepository = new ReservationRepository(_dbContext);

                return _reservationRepository;
            }
            set
            {
                _reservationRepository = value;
            }
        }

        public IDrivenRouteRepository RouteRepository
        {
            get
            {
                if (_routeRepository == null)
                    _routeRepository = new DrivenRouteRepository(_dbContext);
                return _routeRepository;
            }
            set
            {
                _routeRepository = value;
            }
        }
    }
}
