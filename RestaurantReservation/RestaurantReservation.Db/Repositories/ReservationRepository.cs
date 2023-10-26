using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public ReservationRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderMenuItemDetails>> ListOrdersAndMenuItems(int reservationId)
        {
            var query = from order in _dbContext.Set<Order>()
                        where order.ReservationId == reservationId
                        join orderItem in _dbContext.Set<OrderItem>() on order.Id equals orderItem.OrderId
                        join menuItem in _dbContext.Set<MenuItem>() on orderItem.MenuItemId equals menuItem.Id
                        select new OrderMenuItemDetails
                        {
                            OrderId = order.Id,
                            ReservationId = order.ReservationId,
                            OrderDate = order.OrderDate,
                            MenuItemName = menuItem.Name,
                            MenuItemPrice = menuItem.Price,
                            MenuItemDescription = menuItem.Description,
                            RestaurantName = menuItem.Restaurant.Name
                        };

            var results = await query.ToListAsync();
            return results;
        }

    }
}