using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Context;

public class RestaurantReservationDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Table> Tables { get; set; }
    public DbSet<ReservationsFullInfo> ReservationsFullInfo { get; set; }
    public DbSet<EmployeeToRestaurant> EmployeeToRestaurant { get; set; }

    public decimal CalculateRestaurantRevenue(int restaurantId)
        => throw new NotSupportedException();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Data Source=AMRO;Initial Catalog=RestaurantReservationCore;User Id=sa;Password=12345;TrustServerCertificate=True;Encrypt=False;")
            .LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // views mapping 
        modelBuilder.Entity<ReservationsFullInfo>().HasNoKey().ToView(nameof(ReservationsFullInfo));
        modelBuilder.Entity<EmployeeToRestaurant>().HasNoKey().ToView(nameof(EmployeeToRestaurant));

        // function mapping 
        modelBuilder.HasDbFunction(() => CalculateRestaurantRevenue(default))
            .HasName(nameof(CalculateRestaurantRevenue))
            .HasSchema("dbo");

        // resolve cyclic cascading paths 
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Reservation)
            .WithMany(res => res.Orders)
            .HasForeignKey(o => o.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        // seed database with 5 rows for each table 
        List<Customer> customers = 
        [
            new() { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
            new() { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "098-765-4321" },
            new() { CustomerId = 3, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com", PhoneNumber = "111-222-3333" },
            new() { CustomerId = 4, FirstName = "Alice", LastName = "White", Email = "alice.white@example.com", PhoneNumber = "444-555-6666" },
            new() { CustomerId = 5, FirstName = "Charlie", LastName = "Green", Email = "charlie.green@example.com", PhoneNumber = "777-888-9999" }
        ]; 
        modelBuilder.Entity<Customer>().HasData(customers);

        List<Restaurant> restaurants =
        [
            new() { RestaurantId = 1, Name = "The Gourmet Spot", Address = "123 Main St, Cityville", PhoneNumber = "555-1234", OpeningHours = "9 AM - 10 PM" },
            new() { RestaurantId = 2, Name = "Italiano Delight", Address = "456 Elm St, Townsville", PhoneNumber = "555-5678", OpeningHours = "11 AM - 11 PM" },
            new() { RestaurantId = 3, Name = "Sushi Haven", Address = "789 Oak St, Metropolis", PhoneNumber = "555-8765", OpeningHours = "12 PM - 10 PM" },
            new() { RestaurantId = 4, Name = "Burger Bistro", Address = "101 Maple St, Villagetown", PhoneNumber = "555-4321", OpeningHours = "10 AM - 12 AM" },
            new() { RestaurantId = 5, Name = "Veggie Garden", Address = "202 Pine St, Hamlet", PhoneNumber = "555-2468", OpeningHours = "8 AM - 8 PM" }
        ];
        modelBuilder.Entity<Restaurant>().HasData(restaurants);

        List<Table> tables =
        [
            new() { TableId = 1, RestaurantId = 1, Capacity = 4 },
            new() { TableId = 2, RestaurantId = 1, Capacity = 2 },
            new() { TableId = 3, RestaurantId = 2, Capacity = 6 },
            new() { TableId = 4, RestaurantId = 3, Capacity = 4 },
            new() { TableId = 5, RestaurantId = 4, Capacity = 8 }
        ];
        modelBuilder.Entity<Table>().HasData(tables);

        List<Employee> employees =
        [
            new() { EmployeeId = 1, RestaurantId = 1, FirstName = "John", LastName = "Doe", Position = "Chef" },
            new() { EmployeeId = 2, RestaurantId = 1, FirstName = "Jane", LastName = "Smith", Position = "Server" },
            new() { EmployeeId = 3, RestaurantId = 2, FirstName = "Emily", LastName = "Brown", Position = "Manager" },
            new() { EmployeeId = 4, RestaurantId = 3, FirstName = "Michael", LastName = "Johnson", Position = "Bartender" },
            new() { EmployeeId = 5, RestaurantId = 4, FirstName = "Sarah", LastName = "Lee", Position = "Host" }
        ];
        modelBuilder.Entity<Employee>().HasData(employees);

        List<Reservation> reservations =
        [
            new() { ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = DateTime.Parse("2023-11-15 18:00"), PartySize = 4 },
            new() { ReservationId = 2, CustomerId = 2, RestaurantId = 1, TableId = 2, ReservationDate = DateTime.Parse("2023-11-16 19:00"), PartySize = 2 },
            new() { ReservationId = 3, CustomerId = 3, RestaurantId = 2, TableId = 3, ReservationDate = DateTime.Parse("2023-11-17 20:00"), PartySize = 6 },
            new() { ReservationId = 4, CustomerId = 4, RestaurantId = 3, TableId = 4, ReservationDate = DateTime.Parse("2023-11-18 17:30"), PartySize = 4 },
            new() { ReservationId = 5, CustomerId = 5, RestaurantId = 4, TableId = 5, ReservationDate = DateTime.Parse("2023-11-19 18:30"), PartySize = 8 }
        ];
        modelBuilder.Entity<Reservation>().HasData(reservations);

        List<Order> orders =
        [
            new() { OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = DateTime.Parse("2023-11-15 18:30"), TotalAmount = 120 },
            new() { OrderId = 2, ReservationId = 2, EmployeeId = 2, OrderDate = DateTime.Parse("2023-11-16 19:30"), TotalAmount = 75 },
            new() { OrderId = 3, ReservationId = 3, EmployeeId = 3, OrderDate = DateTime.Parse("2023-11-17 20:15"), TotalAmount = 200 },
            new() { OrderId = 4, ReservationId = 4, EmployeeId = 4, OrderDate = DateTime.Parse("2023-11-18 18:00"), TotalAmount = 90 },
            new() { OrderId = 5, ReservationId = 5, EmployeeId = 5, OrderDate = DateTime.Parse("2023-11-19 19:00"), TotalAmount = 150 }
        ];
        modelBuilder.Entity<Order>().HasData(orders);

        List<MenuItem> menuItems =
        [
            new() { ItemId = 1, RestaurantId = 1, Name = "Margherita Pizza", Description = "Classic pizza with tomato sauce and mozzarella", Price = 10.99 },
            new() { ItemId = 2, RestaurantId = 1, Name = "Caesar Salad", Description = "Crisp romaine lettuce with Caesar dressing and croutons", Price = 8.99 },
            new() { ItemId = 3, RestaurantId = 2, Name = "Burger", Description = "Grilled beef patty with lettuce, tomato, and cheese", Price = 12.50 },
            new() { ItemId = 4, RestaurantId = 2, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 14.00 },
            new() { ItemId = 5, RestaurantId = 3, Name = "Chicken Wings", Description = "Spicy chicken wings with a side of ranch", Price = 9.75 }
        ];
        modelBuilder.Entity<MenuItem>().HasData(menuItems);

        List<OrderItem> orderItems =
        [
            new() { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
            new() { OrderItemId = 2, OrderId = 1, ItemId = 2, Quantity = 1 },
            new() { OrderItemId = 3, OrderId = 2, ItemId = 3, Quantity = 3 },
            new() { OrderItemId = 4, OrderId = 3, ItemId = 4, Quantity = 1 },
            new() { OrderItemId = 5, OrderId = 3, ItemId = 5, Quantity = 4 }
        ];
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
    }
}
