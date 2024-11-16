using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository(RestaurantReservationDbContext context)
{
    public async Task AddCustomerAsync(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
        var customer = await context.Customers.FindAsync(customerId);
        if (customer != null)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Customer>> GetCustomersHaveReservationsWithPartySizeGreaterThanAsync(int partySize)
    {
        return await context.Customers
            .FromSqlInterpolated($"EXEC dbo.FindCustomersWithReservationsPartySizeGreaterThan @pSize = {partySize};")
            .ToListAsync();
    }
}
