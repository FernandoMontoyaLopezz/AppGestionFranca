using System.Collections.Generic;
namespace  AppGestionFranca.Models
{

    public partial class Subsidiary
    {
        public int SubsidiaryId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public virtual ICollection<Technician> Technicians { get; set; } = new List<Technician>();
    }
}