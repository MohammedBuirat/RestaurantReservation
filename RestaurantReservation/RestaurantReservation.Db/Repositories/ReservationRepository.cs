using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;

        public ReservationRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            _dbContext.Entry(reservation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int reservationId)
        {
            var reservation = await _dbContext.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _dbContext.Reservations.Remove(reservation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Reservation?> GetByIdAsync(int reservationId)
        {
            return await _dbContext.Reservations.FindAsync(reservationId);
        }

        public async Task<bool> ExistsAsync(int reservationId)
        {
            return await _dbContext.Reservations.AnyAsync(r => r.Id == reservationId);
        }

        public async Task<List<Reservation>?> GetAllAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsByCustomer(int CustomerId)
        {
            return await _dbContext.Set<Reservation>().Where(r => r.CustomerId == CustomerId).ToListAsync();
        }

        public async Task<List<object>> ListOrdersAndMenuItems(int reservationId)
        {
            var query = from order in _dbContext.Set<Order>()
                        where order.ReservationId == reservationId
                        join orderItem in _dbContext.Set<OrderItem>()
                        on order.Id equals orderItem.OrderId
                        join menuItem in _dbContext.Set<MenuItem>()
                        on orderItem.MenuItemId equals menuItem.Id
                        select new
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
            return results.Cast<object>().ToList();
        }
    }
}