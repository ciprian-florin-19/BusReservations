namespace BusReservations.Core.Domain.SeatModel
{
    public class ElderlySeat : Seat
    {
        public ElderlySeat(int seatNumber) : base(seatNumber)
        {
        }

        public override string? Type { get => "elderly"; set => base.Type = value; }
        public override float Discount { get => 50; set => base.Discount = value; }
    }
}
