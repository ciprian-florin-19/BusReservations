namespace BusReservations.Core.Domain.SeatModel
{
    public class StudentSeat : Seat
    {
        public StudentSeat(int seatNumber) : base(seatNumber)
        {
        }

        public override string? Type { get => "regular"; set => base.Type = value; }
        public override float Discount { get => 25; set => base.Discount = value; }

    }

}
