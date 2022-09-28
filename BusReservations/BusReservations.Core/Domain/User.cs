namespace BusReservations.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public Status Status { get; set; } = Status.regular;

        public List<Account> Accounts { get; set; }
    }
}
