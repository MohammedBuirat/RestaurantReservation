using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservation.Db.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReservation.Db.Repositories.IRepostories
{
    public interface ITableRepository : IRepository<Table>
    {
    }
}
