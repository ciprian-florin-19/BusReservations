using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;
        private LocalBackupUtilities _localBackupUtilities;
        private bool _isBackedUp = false;

        public bool IsBackedUp => _isBackedUp;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
            _localBackupUtilities = new LocalBackupUtilities();
        }

        public void AddUser(User user)
        {
            _appDBContext.Users?.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDBContext.Users.ToList();
        }

        public void CreateLocalBackup(string fileName)
        {
            string backupFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Backup\\");
            Directory.CreateDirectory(backupFilePath);
            _localBackupUtilities.WriteCollectionToFile(_appDBContext.Users, backupFilePath + fileName);
            _isBackedUp = true;
        }

    }
}

