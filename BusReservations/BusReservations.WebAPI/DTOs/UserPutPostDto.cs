using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class UserPutPostDto
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Status Status { get; set; }
    }
}
