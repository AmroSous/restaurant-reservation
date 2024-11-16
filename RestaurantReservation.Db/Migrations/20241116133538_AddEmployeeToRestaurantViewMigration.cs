using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeToRestaurantViewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW dbo.EmployeesToRestaurant 
                AS 
                SELECT 
	                e.EmployeeId,
	                e.FirstName + ' ' + e.LastName AS EmployeeFullName,
	                e.Position AS EmployeePosition,
	                r.RestaurantId,
	                r.Name AS RestaurantName, 
	                r.OpeningHours AS RestaurantOpeningHours, 
	                r.PhoneNumber AS RestaurantPhoneNumber,
	                r.Address AS RestaurantAddress
                FROM dbo.Employees AS e 
                LEFT JOIN dbo.Restaurants AS r
                ON e.RestaurantId = r.RestaurantId;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"DROP VIEW dbo.EmployeesToRestaurant;");
        }
    }
}
