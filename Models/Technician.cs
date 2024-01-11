
namespace  AppGestionFranca.Models
{
    public partial class Technician
    {
        public int TechnicianId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public decimal Salary { get; set; }

        public int SubsidiaryId { get; set; }

        public virtual Subsidiary Subsidiary { get; set; } = null!;

        public virtual ICollection<TechnicianItem> TechnicianItems { get; set; } = new List<TechnicianItem>();
    }
}