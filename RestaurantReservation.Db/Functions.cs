using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db
{
    public class Functions
    {
        private readonly DbContext _dbContext;

        public Functions(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<decimal?> CalculateTotalRestaurantRevenue(int restaurantId)
        {
            var parameter = new SqlParameter("@restaurantId", restaurantId);

            var result = await _dbContext.Set<TotalRevenueDto>()
                .FromSqlRaw("SELECT dbo.CalculateTotalRevenue(@restaurantId) AS TotalRevenue", parameter)
                .Select(x => x.TotalRevenue)
                .FirstOrDefaultAsync();

            return result;
        }

        private class TotalRevenueDto
        {
            public decimal? TotalRevenue { get; set; }
        }
    }
}
