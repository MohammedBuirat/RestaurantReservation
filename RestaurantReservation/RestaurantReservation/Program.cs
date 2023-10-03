using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories;
using System;
using System.Threading.Tasks;

namespace RestaurantReservation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("hELLO WORLD");
            await op(); 
            Console.WriteLine("hELLO WORLD");
        }

        static async Task op()
        {
            RestaurantReservationDbContext _context = new RestaurantReservationDbContext();
            CustomerRepository customerRepository = new CustomerRepository(_context);
            var customers = await customerRepository.GetAllAsync(); 

            foreach (var customer in customers)
            {
                Console.WriteLine(customer.FirstName);
            }
        }
    }
}
