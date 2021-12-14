namespace CondoManager.Models
{
    public class Apartment : Entity
    {
        //usando string ao invés de int para possíveis regras de negócio, como apartamento 001
        public string Number { get; set; }
        public int Floor { get ; set; }
        public List<Resident>? ResidentList { get; set; } = null;
        public int? CondoBlockId { get; set; }
        public virtual CondoBlock? CondoBlock { get; set; } = null;
    }
}