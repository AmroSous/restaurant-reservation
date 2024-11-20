using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository(RestaurantReservationDbContext context)
{
    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
        context.MenuItems.Add(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        context.MenuItems.Update(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(int itemId)
    {
        var menuItem = await context.MenuItems.FindAsync(itemId);
        if (menuItem != null)
        {
            context.MenuItems.Remove(menuItem);
            await context.SaveChangesAsync();
        }
    }
}
