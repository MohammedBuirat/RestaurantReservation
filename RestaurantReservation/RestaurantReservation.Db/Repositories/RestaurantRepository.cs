using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public RestaurantRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _dbContext.Entry(restaurant).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants.FindAsync(restaurantId);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Restaurant?> GetByIdAsync(int restaurantId)
        {
            return await _dbContext.Restaurants.FindAsync(restaurantId);
        }

        public async Task<bool> ExistsAsync(int restaurantId)
        {
            return await _dbContext.Restaurants.AnyAsync(r => r.Id == restaurantId);
        }

        public async Task<List<Restaurant>?> GetAllAsync()
        {
            return await _dbContext.Restaurants.ToListAsync();
        }
    }
}
