namespace BusReservations.WebAPI.DTOs
{
    public class AccountPutPostDto
    {
        public UserPutPostDto User { get; set; }
        public bool HasAdminPrivileges { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
