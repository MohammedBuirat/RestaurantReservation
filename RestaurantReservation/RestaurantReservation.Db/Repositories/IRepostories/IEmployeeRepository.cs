using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories.IRepostories
{
    public interface IEmployeeRepository
    {
        public Task<decimal?> CalculateAverageOrderAmount(int EmployeeId);
    }
}
