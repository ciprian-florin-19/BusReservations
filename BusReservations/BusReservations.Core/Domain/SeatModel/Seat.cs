namespace BusReservations.Core.Domain.SeatModel
{
    public class Seat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual Status Type { get; set; }
        public virtual float Discount { get; set; }
        public int SeatNumber { get; set; }

        public Seat()
        {

        }
        public Seat(int seatNumber, Status type)
        {
            SeatNumber = seatNumber;
            Type = type;
            switch (Type)
            {
                case Status.student:
                    Discount = 25;
                    break;
                case Status.elderly:
                    Discount = 50;
                    break;
                default:
                    Discount = 0;
                    break;
            }
        }
    }
}