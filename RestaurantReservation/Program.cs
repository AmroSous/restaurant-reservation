using RestaurantReservation.Db.Context;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using RestaurantReservationDbContext context = new();

static string ToJSON(object obj)
{
    //return JsonSerializer.Serialize(obj, new JsonSerializerOptions
    //{
    //    WriteIndented = true,
    //    ReferenceHandler = ReferenceHandler.IgnoreCycles
    //});

    return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
    {
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    });
}

// create repositories 

OrderRepository orderRepository = new(context);
EmployeeRepository employeeRepository = new(context);
ReservationRepository reservationRepository = new(context);
CustomerRepository customerRepository = new(context);

// test

var result = await customerRepository.GetCustomersHaveReservationsWithPartySizeGreaterThanAsync(4);
Console.WriteLine(ToJSON(result));
