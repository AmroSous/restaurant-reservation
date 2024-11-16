using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationViewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW dbo.ReservationsFullInfo 
                AS 
                SELECT 
	                reserv.ReservationId,
	                reserv.PartySize,
	                reserv.ReservationDate,
	                reserv.TableId,
	                cust.CustomerId,
	                cust.Email AS CustomerEmail,
	                cust.FirstName + ' ' + cust.LastName AS CustomerFullName,
	                cust.PhoneNumber AS CustomerPhoneNumber,
	                rest.RestaurantId,
	                rest.Address AS RestaurantAddress,
	                rest.Name AS RestaurantName,
	                rest.OpeningHours AS RestaurantOpeningHours,
	                rest.PhoneNumber AS RestaurantPhoneNumber
                FROM dbo.Reservations As reserv
                LEFT JOIN dbo.Customers AS cust 
                ON cust.CustomerId = reserv.CustomerId 
                LEFT JOIN dbo.Restaurants AS rest 
                ON rest.RestaurantId = reserv.RestaurantId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW dbo.ReservationsFullInfo");
        }
    }
}
