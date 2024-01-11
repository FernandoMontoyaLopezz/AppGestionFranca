
using  AppGestionFranca.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace  AppGestionFranca.Data
{
    public class SubsidiaryDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubsidiaryId { get; set; }
        public string Code { get; set; } = null!; 
        public string Name { get; set; } = null!;
        public virtual ICollection<Technician> Technicians { get; set; } = new List<Technician>();


    }
}
