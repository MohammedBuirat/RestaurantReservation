using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW ReservationDetails AS
        SELECT
            r.Id AS ReservationId,
            r.ReservationDate,
            r.PartySize,
            c.Id AS CustomerId,
            c.FirstName AS CustomerFirstName,
            c.LastName AS CustomerLastName,
            c.Email AS CustomerEmail,
            c.PhoneNumber AS CustomerPhoneNumber,
            rest.Id AS RestaurantId,
            rest.Name AS RestaurantName,
            rest.Address AS RestaurantAddress,
            rest.PhoneNumber AS RestaurantPhoneNumber,
            rest.OpeningHours AS RestaurantOpeningHours,
            t.Id AS TableId
        FROM
            Reservations r
        JOIN
            Customers c ON r.CustomerId = c.Id
        JOIN
            Restaurants rest ON r.RestaurantId = rest.Id
        JOIN
            [Tables] t ON r.TableId = t.Id;
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW ReservationDetails;");
        }
    }
}
