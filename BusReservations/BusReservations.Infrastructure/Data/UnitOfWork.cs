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
        private IReservationRepository? _reservationRepository;
        private IDrivenRouteRepository? _routeRepository;
        private IAccountRepository? _accountRepository;

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

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_dbContext);
                return _accountRepository;
            }
            set
            {
                _accountRepository = value;
            }
        }
    }
}
