using System.Xml.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string ConnectionString = ConfigurationManager.AppSettings["SqlConnectionString"];
            Console.WriteLine(ConnectionString);
            await op(ConnectionString); 
        }

        static async Task op(string ConnectionString)
        {
            RestaurantReservationDbContext _context = new RestaurantReservationDbContext(ConnectionString);
            CustomerRepository customerRepository = new CustomerRepository(_context);
            var customers = await customerRepository.GetAllAsync();

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }
    }
}
