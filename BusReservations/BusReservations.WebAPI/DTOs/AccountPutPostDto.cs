using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class AccountPutPostDto
    {
        [Required]
        public UserPutPostDto User { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
