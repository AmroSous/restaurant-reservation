using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderId { get; set; }

    [ForeignKey("ReservationId")] 
    public Reservation? Reservation { get; set; }

    public int ReservationId {  get; set; }

    [ForeignKey("EmployeeId")]
    public Employee? Employee { get; set; }

    public int EmployeeId { get; set; }

    public DateTime OrderDate {  get; set; } = DateTime.Now;

    [Range(0, int.MaxValue)]
    public int TotalAmount {  get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
