using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
