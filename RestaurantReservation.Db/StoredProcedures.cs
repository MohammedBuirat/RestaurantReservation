using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using System;

public class StoredProcedures
{
	private readonly DbContext _dbContext;
	public StoredProcedures(DbContext dbContext)
	{
		_dbContext = dbContext;
	}

    public async Task<List<Customer>> FindCustomersWithLargePartiesAsync(int partySizeThreshold)
    {
        var partySizeParameter = new SqlParameter("@partySizeThreshold", partySizeThreshold);
        var result = await _dbContext.Set<Customer>()
            .FromSqlRaw("EXEC FindCustomersWithLargeParties @partySizeThreshold", partySizeParameter)
            .ToListAsync();

        return result;
    }

}
