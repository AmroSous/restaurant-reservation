using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedureMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE PROCEDURE dbo.FindCustomersWithReservationsPartySizeGreaterThan(
	                @pSize int = 0)
                AS 
                BEGIN
	                SELECT DISTINCT 
		                c.CustomerId,
		                c.Email,
		                c.FirstName,
		                c.LastName,
		                c.PhoneNumber
	                FROM dbo.Customers AS c
	                INNER JOIN dbo.Reservations AS r
	                ON c.CustomerId = r.CustomerId
	                WHERE r.PartySize > @pSize
                END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP PROCEDURE dbo.FindCustomersWithReservationsPartySizeGreaterThan");
        }
    }
}
