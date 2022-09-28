using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core.Domain
{
    public class Account : IdentityUser
    {
        public User User { get; set; }
        public bool HasAdminPrivileges { get; set; } = false;
        public override string UserName { get; set; }
        public string Password { get; set; }
    }
}
