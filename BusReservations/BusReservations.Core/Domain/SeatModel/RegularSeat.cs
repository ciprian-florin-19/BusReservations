namespace BusReservations.Core.Domain.SeatModel
{
    public class RegularSeat : Seat
    {
        public RegularSeat(int seatNumber) : base(seatNumber)
        {
            Type = Status.regular;
            Discount = 0;
        }
    }
}
