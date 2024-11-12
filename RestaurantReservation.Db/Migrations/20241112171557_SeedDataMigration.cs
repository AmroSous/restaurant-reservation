using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John", "Doe", "123-456-7890" },
                    { 2, "jane.smith@example.com", "Jane", "Smith", "098-765-4321" },
                    { 3, "bob.brown@example.com", "Bob", "Brown", "111-222-3333" },
                    { 4, "alice.white@example.com", "Alice", "White", "444-555-6666" },
                    { 5, "charlie.green@example.com", "Charlie", "Green", "777-888-9999" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "RestaurantId", "Address", "Name", "OpeningHours", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, Cityville", "The Gourmet Spot", "9 AM - 10 PM", "555-1234" },
                    { 2, "456 Elm St, Townsville", "Italiano Delight", "11 AM - 11 PM", "555-5678" },
                    { 3, "789 Oak St, Metropolis", "Sushi Haven", "12 PM - 10 PM", "555-8765" },
                    { 4, "101 Maple St, Villagetown", "Burger Bistro", "10 AM - 12 AM", "555-4321" },
                    { 5, "202 Pine St, Hamlet", "Veggie Garden", "8 AM - 8 PM", "555-2468" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Position", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "John", "Doe", "Chef", 1 },
                    { 2, "Jane", "Smith", "Server", 1 },
                    { 3, "Emily", "Brown", "Manager", 2 },
                    { 4, "Michael", "Johnson", "Bartender", 3 },
                    { 5, "Sarah", "Lee", "Host", 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "ItemId", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Classic pizza with tomato sauce and mozzarella", "Margherita Pizza", 10.99, 1 },
                    { 2, "Crisp romaine lettuce with Caesar dressing and croutons", "Caesar Salad", 8.9900000000000002, 1 },
                    { 3, "Grilled beef patty with lettuce, tomato, and cheese", "Burger", 12.5, 2 },
                    { 4, "Creamy Alfredo sauce with fettuccine pasta", "Pasta Alfredo", 14.0, 2 },
                    { 5, "Spicy chicken wings with a side of ranch", "Chicken Wings", 9.75, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 2, 1 },
                    { 3, 6, 2 },
                    { 4, 4, 3 },
                    { 5, 8, 4 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 11, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, 2, new DateTime(2023, 11, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 3, 6, new DateTime(2023, 11, 17, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, 4, 4, new DateTime(2023, 11, 18, 17, 30, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 5, 5, 8, new DateTime(2023, 11, 19, 18, 30, 0, 0, DateTimeKind.Unspecified), 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "EmployeeId", "OrderDate", "ReservationId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 15, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 120 },
                    { 2, 2, new DateTime(2023, 11, 16, 19, 30, 0, 0, DateTimeKind.Unspecified), 2, 75 },
                    { 3, 3, new DateTime(2023, 11, 17, 20, 15, 0, 0, DateTimeKind.Unspecified), 3, 200 },
                    { 4, 4, new DateTime(2023, 11, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 4, 90 },
                    { 5, 5, new DateTime(2023, 11, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 5, 150 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "ItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 2, 3 },
                    { 4, 4, 3, 1 },
                    { 5, 5, 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "ItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "RestaurantId",
                keyValue: 2);
        }
    }
}
