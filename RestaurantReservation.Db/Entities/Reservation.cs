using System;
using System.Collections.Generic;

namespace RestaurantReservation.Db.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Table Table { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        public List<Order> Orders { get; set; } // Corrected property declaration
    }
}
