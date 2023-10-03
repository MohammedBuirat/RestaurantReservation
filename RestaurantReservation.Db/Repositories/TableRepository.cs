using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    internal class TableRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public TableRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Table table)
        {
            _dbContext.Tables.Add(table);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table table)
        {
            _dbContext.Entry(table).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int tableId)
        {
            var table = await _dbContext.Tables.FindAsync(tableId);
            if (table != null)
            {
                _dbContext.Tables.Remove(table);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Table?> GetByIdAsync(int tableId)
        {
            return await _dbContext.Tables.FindAsync(tableId);
        }

        public async Task<bool> ExistsAsync(int tableId)
        {
            return await _dbContext.Tables.AnyAsync(t => t.Id == tableId);
        }

        public async Task<List<Table>?> GetAllAsync()
        {
            return await _dbContext.Tables.ToListAsync();
        }
    }
}
