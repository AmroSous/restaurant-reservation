using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models;

public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MinLength(1, ErrorMessage = "Email cannot be empty.")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [MinLength(1, ErrorMessage = "Phone cannot be empty.")]
    public string PhoneNumber { get; set; } = string.Empty;

    public ICollection<Reservation> Reservations { get; set; } = [];
}
