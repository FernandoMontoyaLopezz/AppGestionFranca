
using AppGestionFranca.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppGestionFranca.Data
{
    public class ItemDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<TechnicianItem> TechnicianItems { get; set; } = new List<TechnicianItem>();


    }
}
