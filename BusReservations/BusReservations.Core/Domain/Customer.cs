namespace BusReservations.Core.Domain
{
    public class Customer : User
    {
        public Status? Status { get; set; }
        public Customer(User user, Status status)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Status = status;
        }
        public Customer()
        {

        }
    }
}
