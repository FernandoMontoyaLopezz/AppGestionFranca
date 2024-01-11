
using  AppGestionFranca.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  AppGestionFranca.Data
{
    public class TechnicianDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnicianId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Este campo solo permite letras y números")]
        public string Code { get; set; } = null!; 

        [Required]
        public decimal Salary { get; set; }

        public int SubsidiaryId { get; set; }

        public virtual ICollection<TechnicianItem> TechnicianItems { get; set; } = new List<TechnicianItem>();

    }
}
