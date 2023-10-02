using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    internal class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public MenuItemRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MenuItem menuItem)
        {
            _dbContext.MenuItems.Add(menuItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MenuItem menuItem)
        {
            _dbContext.Entry(menuItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int menuItemId)
        {
            var menuItem = await _dbContext.MenuItems.FindAsync(menuItemId);
            if (menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<MenuItem> GetByIdAsync(int menuItemId)
        {
            return await _dbContext.MenuItems.FindAsync(menuItemId);
        }

        public async Task<bool> ExistsAsync(int menuItemId)
        {
            return await _dbContext.MenuItems.AnyAsync(m => m.Id == menuItemId);
        }

        public async Task<List<MenuItem>> GetAllAsync()
        {
            return await _dbContext.MenuItems.ToListAsync();
        }

        public async Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId)
        {
            var query = from order in _dbContext.Set<Order>()
                        where order.ReservationId == ReservationId
                        join orderItem in _dbContext.Set<OrderItem>()
                        on order.Id equals orderItem.OrderId
                        join menuItem in _dbContext.Set<MenuItem>()
                        on orderItem.MenuItemId equals menuItem.Id
                        select menuItem;

            var menuItems = await query.ToListAsync();
            return menuItems;
        }
    }
}
