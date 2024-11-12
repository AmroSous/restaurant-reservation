using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeId { get; set; }

    [ForeignKey("RestaurantId")]
    public Restaurant? Restaurant { get; set; }

    public int RestaurantId { get; set; }

    [Required]
    [StringLength(10, MinimumLength=2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = [];
}
