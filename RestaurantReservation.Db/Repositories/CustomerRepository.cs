using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    internal class CustomerRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public CustomerRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _dbContext.Customers.FindAsync(customerId);
        }

        public async Task<bool> ExistsAsync(int customerId)
        {
            return await _dbContext.Customers.AnyAsync(c => c.Id == customerId);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }
    }
}
