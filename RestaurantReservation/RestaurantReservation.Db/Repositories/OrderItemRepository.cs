using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public OrderItemRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            _dbContext.Entry(orderItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderItemId)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderItem?> GetByIdAsync(int orderItemId)
        {
            return await _dbContext.OrderItems.FindAsync(orderItemId);
        }

        public async Task<bool> ExistsAsync(int orderItemId)
        {
            return await _dbContext.OrderItems.AnyAsync(oi => oi.Id == orderItemId);
        }

        public async Task<List<OrderItem>?> GetAllAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }
    }
}
