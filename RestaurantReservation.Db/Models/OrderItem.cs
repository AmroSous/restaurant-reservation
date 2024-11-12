using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderItemId { get; set; }

    [ForeignKey("OrderId")]
    public Order? Order {  get; set; }

    public int OrderId { get; set; }

    [ForeignKey("ItemId")] 
    public MenuItem? Item { get; set; }

    public int ItemId { get; set; }

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}
