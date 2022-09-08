using System.ComponentModel.DataAnnotations;

namespace BusReservations.WebAPI.DTOs
{
    public class DrivenRoutePutPostDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Start { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Destination { get; set; }

        [Required]
        public TimeTablePutPostDto TimeTable { get; set; }

        [Required]
        [Range(20, 100)]
        public float SeatPrice { get; set; }

    }
}
