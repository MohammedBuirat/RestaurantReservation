using RestaurantReservation.Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories.IRepostories
{
    public interface IMenuItemRepository
    {
        public Task<List<MenuItem>> ListOrderedMenuItems(int ReservationId);
    }
}
