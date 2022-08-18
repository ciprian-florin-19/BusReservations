using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public bool HasAdminPrivileges { get; set; }
        public string Username { get; }
        public string Password { get; }
    }
}
