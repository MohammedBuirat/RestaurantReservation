using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    internal class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public EmployeeRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetByIdAsync(int employeeId)
        {
            return await _dbContext.Employees.FindAsync(employeeId);
        }

        public async Task<bool> ExistsAsync(int employeeId)
        {
            return await _dbContext.Employees.AnyAsync(e => e.Id == employeeId);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> ListManagers()
        {
            return await _dbContext.Set<Employee>().Where(e => e.Position == "Manager").ToListAsync();
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
