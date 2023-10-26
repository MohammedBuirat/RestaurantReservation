using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public MenuItemRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
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
