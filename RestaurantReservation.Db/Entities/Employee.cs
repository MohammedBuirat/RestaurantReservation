using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public List<Order> Orders { get; set; }


    }
}
