using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository(RestaurantReservationDbContext context)
{
    public async Task AddTableAsync(Table table)
    {
        context.Tables.Add(table);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTableAsync(Table table)
    {
        context.Tables.Update(table);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTableAsync(int tableId)
    {
        var table = await context.Tables.FindAsync(tableId);
        if (table != null)
        {
            context.Tables.Remove(table);
            await context.SaveChangesAsync();
        }
    }
}
