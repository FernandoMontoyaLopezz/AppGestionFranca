using  AppGestionFranca.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace  AppGestionFranca.Data
{
    public class TechnicianItemDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnicianItemId { get; set; }
        public int TechnicianId { get; set; }
        public int ElementId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; } = null!;

        public virtual Technician Technician { get; set; } = null!;
    }
}
