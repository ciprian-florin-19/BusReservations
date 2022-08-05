namespace BusReservations.Core.Domain.SeatModel
{
    public class RegularSeat : Seat
    {
        public RegularSeat(int seatNumber) : base(seatNumber)
        {
        }

        public override string? Type { get => "regular"; set => base.Type = value; }
        public override float Discount { get => 0; set => base.Discount = value; }
    }
}
