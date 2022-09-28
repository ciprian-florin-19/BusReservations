using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class UserGetDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Status { get; set; }
    }
}
