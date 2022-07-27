namespace BusReservations.Core.Domain.BusModel
{
    public class RegularSeat : Seat
    {
        public override string? Type { get => "regular"; set => base.Type = value; }
        public override float Discount { get => 0; set => base.Discount = value; }
    }
}
