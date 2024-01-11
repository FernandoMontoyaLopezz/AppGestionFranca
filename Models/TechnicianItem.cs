
namespace  AppGestionFranca.Models
{

    public partial class TechnicianItem
    {
        public int TechnicianItemId { get; set; }

        public int TechnicianId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public virtual Item Item { get; set; } = null!;

        public virtual Technician Technician { get; set; } = null!;
    }
}
