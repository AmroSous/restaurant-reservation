using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Reservation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReservationId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Owner {  get; set; }

    public int CustomerId { get; set; }

    [ForeignKey("RestaurantId")]
    public Restaurant? Restaurant { get; set; }

    public int RestaurantId { get; set; }

    [ForeignKey("TableId")]
    public Table? Table { get; set; }

    public int TableId { get; set; }

    public DateTime ReservationDate { get; set; } = DateTime.Now;

    [Range(0, int.MaxValue)]
    public int PartySize { get; set; }

    public ICollection<Order> Orders { get; set; } = [];
}
