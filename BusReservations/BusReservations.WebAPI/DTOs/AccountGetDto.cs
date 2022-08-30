using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class AccountGetDto
    {
        public UserGetDto User { get; set; }
        public bool HasAdminPrivileges { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
