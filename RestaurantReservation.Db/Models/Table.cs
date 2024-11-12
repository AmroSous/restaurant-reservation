using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantReservation.Db.Models
{
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant? Restaurant { get; set; }

        public int RestaurantId {  get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity {  get; set; }

        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}