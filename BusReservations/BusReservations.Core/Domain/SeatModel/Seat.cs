namespace BusReservations.Core.Domain.SeatModel
{
    public class Seat
    {
        public virtual Status Type { get; set; }
        public virtual float Discount { get; set; }
        public int SeatNumber { get; set; }

        public Seat(int seatNumber)
        {
            SeatNumber = seatNumber;
        }
    }
}