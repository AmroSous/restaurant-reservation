using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RevenueDBFunctionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE FUNCTION dbo.CalculateRestaurantRevenue (@RestaurantId INT)
                RETURNS DECIMAL(18, 2)
                AS
                BEGIN
                    RETURN (
                        SELECT ISNULL(SUM(oi.Quantity * mi.Price), 0)
                        FROM OrderItems oi
                        INNER JOIN Orders o ON oi.OrderId = o.OrderId
                        INNER JOIN Reservations r ON o.ReservationId = r.ReservationId
		                INNER JOIN MenuItems mi ON mi.ItemId = oi.ItemId
                        WHERE r.RestaurantId = @RestaurantId
                    );
                END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP FUNCTION dbo.CalculateRestaurantRevenue;");
        }
    }
}
