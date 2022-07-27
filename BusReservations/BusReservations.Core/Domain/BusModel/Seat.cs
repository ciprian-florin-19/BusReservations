namespace BusReservations.Core.Domain.BusModel
{
    public class Seat
    {
        public virtual string? Type { get; set; }
        public virtual float Discount { get; set; }
    }
}