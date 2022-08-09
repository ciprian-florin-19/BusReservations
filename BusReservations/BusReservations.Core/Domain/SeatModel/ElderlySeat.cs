namespace BusReservations.Core.Domain.SeatModel
{
    public class ElderlySeat : Seat
    {
        public ElderlySeat(int seatNumber) : base(seatNumber)
        {
        }

        public override Status Type { get => Status.student; set => base.Type = value; }
        public override float Discount { get => 50; set => base.Discount = value; }
    }
}
