using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository(RestaurantReservationDbContext context)
{
    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantAsync(int restaurantId)
    {
        var restaurant = await context.Restaurants.FindAsync(restaurantId);
        if (restaurant != null)
        {
            context.Restaurants.Remove(restaurant);
            await context.SaveChangesAsync();
        }
    }
}
