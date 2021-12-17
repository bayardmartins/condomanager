namespace CondoManager.Models
{
    public class Block : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Apartment>? ApartamentList { get; set; } = null;
        public int? CondoId { get; set; } = null;
        public virtual Condo? Condo { get; set; } = null;
    }
}