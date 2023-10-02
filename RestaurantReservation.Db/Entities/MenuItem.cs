using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int ResturantId { get; set; }
        public Resturant Resturant { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
