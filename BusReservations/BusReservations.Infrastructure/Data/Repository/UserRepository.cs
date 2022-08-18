using BusReservations.Core;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Domain;

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
            _appDBContext.SaveChanges();
        }

        public void CreateLocalBackup(string fileName)
        {
            string backupFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Backup\\");
            Directory.CreateDirectory(backupFilePath);
            LocalBackupUtilities.Instance.WriteCollectionToFile(_appDBContext.Users, backupFilePath + fileName);
            IsBackedUp = true;
        }

        public void DeleteUser(Guid id)
        {
            _appDBContext.Users.Remove(GetUserById(id));
            _appDBContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDBContext.Users.ToPagedList();
        }

        public User GetUserById(Guid id)
        {
            return _appDBContext.Users.FirstOrDefault(User => User.Id == id);
        }

        public void UpdateUser(Guid id, User newUser)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                user = newUser;
                _appDBContext.SaveChanges();
            }
        }
    }
}
