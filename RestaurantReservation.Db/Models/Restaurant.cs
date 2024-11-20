using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId {  get; set; }

        [Required]
        [StringLength(30, MinimumLength=2)]
        public string Name {  get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Phone]
        [Required]
        [MinLength(1, ErrorMessage = "Phone cannot be empty.")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string OpeningHours { get; set; } = string.Empty;

        public ICollection<Reservation> Reservations { get; set; } = [];

        public ICollection<Employee> Employees { get; set; } = [];

        public ICollection<MenuItem> MenuItems { get; set; } = [];
    }
}