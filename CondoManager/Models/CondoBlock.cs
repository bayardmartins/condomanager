namespace CondoManager.Models
{
    public class CondoBlock : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Apartment> ApartamentList { get; set; }
        public int CondoId { get; set; }
        public virtual Condo Condo { get; set; }
    }
}