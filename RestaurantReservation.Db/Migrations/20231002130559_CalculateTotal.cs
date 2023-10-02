using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CalculateTotal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE FUNCTION dbo.CalculateTotalRevenue (@restaurantId INT)
        RETURNS DECIMAL(10, 2)
        AS
        BEGIN
            DECLARE @totalRevenue DECIMAL(10, 2)
            -- Your SQL logic to calculate total revenue for the given restaurant
            -- Example: 
            -- SELECT @totalRevenue = SUM(Price) FROM Orders WHERE RestaurantId = @restaurantId

            RETURN @totalRevenue
        END
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION dbo.CalculateTotalRevenue");
        }
    }
}
