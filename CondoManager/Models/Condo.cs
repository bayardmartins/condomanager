namespace CondoManager.Models
{
    public class Condo : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ManagerEmail { get; set; }
        public virtual ICollection<CondoBlock> BlockList { get;set; }
    }
}