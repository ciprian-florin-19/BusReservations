namespace BusReservations.Core.Domain.SeatModel
{
    public class StudentSeat : Seat
    {
        public StudentSeat(int seatNumber) : base(seatNumber)
        {
        }

        public override Status Type { get => Status.student; set => base.Type = value; }
        public override float Discount { get => 25; set => base.Discount = value; }

    }

}
