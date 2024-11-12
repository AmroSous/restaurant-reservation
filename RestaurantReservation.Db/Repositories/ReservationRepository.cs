using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository(RestaurantReservationDbContext context)
{
    public async Task AddReservationAsync(Reservation reservation)
    {
        context.Reservations.Add(reservation);
        await context.SaveChangesAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        context.Reservations.Update(reservation);
        await context.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(int reservationId)
    {
        var reservation = await context.Reservations.FindAsync(reservationId);
        if (reservation != null)
        {
            context.Reservations.Remove(reservation);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Reservation>> GetReservationsByCustomerAsync(int customerId)
    {
        var customer = await context.Customers.Include(c => c.Reservations).SingleOrDefaultAsync(c => c.CustomerId == customerId);
        if (customer != null) return [.. customer.Reservations];
        throw new InvalidOperationException("Customer not found.");
    }

    public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
    {
        var orderedMenuItems = await context.Orders.Where(o => o.ReservationId == reservationId)
            .Join(context.OrderItems, o => o.OrderId, oi => oi.OrderId, (o, oi) => oi)
            .Join(context.MenuItems, oi => oi.ItemId, mi => mi.ItemId, (oi, mi) => mi)
            .ToListAsync();

        return orderedMenuItems;
    }
}
