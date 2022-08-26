using BusReservations.Core.Domain;

namespace BusReservations.WebAPI.DTOs
{
    public class SeatDto
    {
        public int SeatNumber { get; set; }
        public virtual Status Type { get; set; }
    }
}
