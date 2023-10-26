using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.GenericRepository;
using RestaurantReservation.Db.Repositories.IRepostories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public EmployeeRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal?> CalculateAverageOrderAmount(int EmployeeId)
        {
            var query = from order in _dbContext.Set<Order>()
                        where order.EmployeeId == EmployeeId
                        select order.TotalAmount;

            decimal? averageOrderAmount = await query.AverageAsync();

            return averageOrderAmount;
        }
    }
}
