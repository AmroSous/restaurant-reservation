using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository(RestaurantReservationDbContext context)
{
    public async Task AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await context.Orders.FindAsync(orderId);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Order>> ListOrdersAndMenuItemsAsync(int reservationId)
    {
        var reservation = await context.Reservations
            .Include(r => r.Orders).ThenInclude(o => o.OrderItems)
            .ThenInclude(oi => oi.Item).FirstOrDefaultAsync(r => r.ReservationId == reservationId);

        if (reservation != null) return [.. reservation.Orders];
        throw new InvalidOperationException("Reservation not found.");
    }
}
