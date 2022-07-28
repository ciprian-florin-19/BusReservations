using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext)); 
        }

        public void AddUser(User user)
        {
            _appDBContext.Users?.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDBContext.Users.ToList();
        }
    }
}

