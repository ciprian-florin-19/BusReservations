using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class UserGetDto
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Status { get; set; }
    }
}
