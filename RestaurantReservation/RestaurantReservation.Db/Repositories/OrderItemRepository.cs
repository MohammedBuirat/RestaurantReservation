using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public OrderItemRepository(RestaurantReservationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
