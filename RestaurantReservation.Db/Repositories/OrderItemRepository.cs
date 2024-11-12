using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository(RestaurantReservationDbContext context)
{
    public async Task AddOrderItemAsync(OrderItem orderItem)
    {
        context.OrderItems.Add(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        context.OrderItems.Update(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int orderItemId)
    {
        var orderItem = await context.OrderItems.FindAsync(orderItemId);
        if (orderItem != null)
        {
            context.OrderItems.Remove(orderItem);
            await context.SaveChangesAsync();
        }
    }
}
