namespace RestaurantReservation.Db.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}