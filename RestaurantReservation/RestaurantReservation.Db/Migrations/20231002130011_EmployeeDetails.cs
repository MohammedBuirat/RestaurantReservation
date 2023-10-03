using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW EmployeeRestaurantView AS
                SELECT
                    e.Id AS EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.Position,
                    r.Id AS RestaurantId,
                    r.Name AS RestaurantName,
                    r.Address AS RestaurantAddress,
                    r.PhoneNumber AS RestaurantPhoneNumber,
                    r.OpeningHours AS RestaurantOpeningHours
                FROM
                    Employees e
                JOIN
                    Restaurants r ON e.RestaurantId = r.Id;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW EmployeeRestaurantView;");
        }
    }
}
