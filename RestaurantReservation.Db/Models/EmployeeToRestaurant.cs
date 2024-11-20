namespace RestaurantReservation.Db.Models;

public class EmployeeToRestaurant
{
	public int EmployeeId;
	public string EmployeeFullName = string.Empty;
	public string EmployeePosition = string.Empty;
	public int RestaurantId;
	public string RestaurantName = string.Empty;
	public string RestaurantOpeningHours = string.Empty;
	public string RestaurantPhoneNumber = string.Empty;
	public string RestaurantAddress = string.Empty;
}
