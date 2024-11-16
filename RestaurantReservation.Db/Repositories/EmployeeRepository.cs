using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository(RestaurantReservationDbContext context)
{
    public async Task AddEmployeeAsync(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int employeeId)
    {
        var employee = await context.Employees.FindAsync(employeeId);
        if (employee != null)
        {
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }

    public async Task<List<Employee>> ListManagersAsync()
    {
        return await context.Employees.Where(e => e.Position == "Manager").ToListAsync();
    }

    public async Task<double> CalculateAverageOrderAmountAsync(int employeeId)
    {
        return await context.Orders.Where(o => o.EmployeeId == employeeId)
            .Select(o => o.TotalAmount).DefaultIfEmpty().AverageAsync();
    }

    public async Task<List<EmployeeToRestaurant>> GetEmployeesWithRestaurantInfoAsync()
    {
        return await context.EmployeeToRestaurant.ToListAsync();
    }
}
