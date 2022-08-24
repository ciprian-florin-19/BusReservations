using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservations.Infrastructure.Data.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public bool IsBackedUp { get; private set; } = false;

        public void AddUser(User user)
        {
            _appDBContext.Users.Add(user);
        }

        public void CreateLocalBackup(string fileName)
        {
            string backupFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Backup\\");
            Directory.CreateDirectory(backupFilePath);
            LocalBackupUtilities.Instance.WriteCollectionToFile(_appDBContext.Users, backupFilePath + fileName);
            IsBackedUp = true;
        }

        public void DeleteUser(User user)
        {
            _appDBContext.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _appDBContext.Users.ToPagedListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _appDBContext.Users.SingleOrDefaultAsync(User => User.Id == id);
            return user;
        }

        public void UpdateUser(User user)
        {
            _appDBContext.Update(user);
        }
    }
}
