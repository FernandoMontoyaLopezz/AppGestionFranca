
namespace  AppGestionFranca.Models
{

    public partial class Item
    {
        public int ItemId { get; set; }

        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public virtual ICollection<TechnicianItem> TechnicianItems { get; set; } = new List<TechnicianItem>();
    }
}