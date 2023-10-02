using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public Table Table { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PartySize { get; set; }
        List<Order> Orders { get; set; }
    }
}
