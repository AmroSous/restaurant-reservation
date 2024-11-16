using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Models;

[Keyless]
public class ReservationsFullInfo
{
	public int ReservationId;
	public int PartySize;
	public DateTime ReservationDate;
	public int? TableId;
	public int? CustomerId;
	public string CustomerEmail = string.Empty;
	public string CustomerFullName = string.Empty;
	public string CustomerPhoneNumber = string.Empty;
	public int? RestaurantId;
	public string RestaurantAddress = string.Empty;
	public string RestaurantName = string.Empty;
	public string RestaurantOpeningHours = string.Empty;
	public string RestaurantPhoneNumber = string.Empty;
}
