using BusReservations.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class UserPutPostDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public Status Status { get; set; }
    }
}
