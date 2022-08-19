namespace BusReservations.Core.Domain.SeatModel
{
    public class StudentSeat : Seat
    {
        public StudentSeat(int seatNumber) : base(seatNumber)
        {
            Type = Status.student;
            Discount = 25;
        }
    }

}
