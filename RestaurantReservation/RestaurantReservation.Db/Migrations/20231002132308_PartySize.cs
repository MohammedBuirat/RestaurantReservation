using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class PartySize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE PROCEDURE FindCustomersWithLargeParties
            @partySizeThreshold INT
        AS
        BEGIN
            SELECT c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber
            FROM Customers c
            INNER JOIN Reservations r ON c.Id = r.CustomerId
            WHERE r.PartySize > @partySizeThreshold;
        END
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS FindCustomersWithLargeParties;");
        }
    }
}
