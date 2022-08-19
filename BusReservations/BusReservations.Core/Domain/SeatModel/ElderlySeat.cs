namespace BusReservations.Core.Domain.SeatModel
{
    public class ElderlySeat : Seat
    {
        public ElderlySeat(int seatNumber) : base(seatNumber)
        {
            Type = Status.elderly;
            Discount = 50;
        }
    }
}
