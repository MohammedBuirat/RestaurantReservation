using Microsoft.EntityFrameworkCore;
using System.Configuration; 
using RestaurantReservation.Db.Entities;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace RestaurantReservation.Db
{
    
    public class RestaurantReservationDbContext : DbContext
    {
        private string connectionString;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }

        public RestaurantReservationDbContext(string conn)
        {
            connectionString = conn;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.Write(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
