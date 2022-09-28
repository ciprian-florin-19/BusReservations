using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusReservations.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext ?? throw new ArgumentNullException(nameof(appDBContext));
        }

        public bool IsBackedUp { get; private set; } = false;

        public void AddRange(IEnumerable<User> users)
        {
            _appDBContext.Users.AddRange(users);
        }

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

        public async Task<IEnumerable<User>> GetAllUsers(int index = 1)
        {
            return await _appDBContext.Users.ToPagedListAsync(index);
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _appDBContext.Users.SingleOrDefaultAsync(User => User.Id == id);
            return user;
        }

        public async Task<User> DoesUserExist(User user)
        {
            return await _appDBContext.Users.SingleOrDefaultAsync(
                u => u.FullName == user.FullName
                && u.PhoneNumber == user.PhoneNumber
                && u.Email == user.Email);
        }

        public async Task<IEnumerable<User>> GetUsersByStatus(Status status, int index = 1)
        {
            return await _appDBContext.Users.Where(u => u.Status == status).ToPagedListAsync(index);
        }

        public void UpdateUser(User user)
        {
            _appDBContext.Update(user);
        }
    }
}
