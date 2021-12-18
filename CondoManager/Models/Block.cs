using System.ComponentModel.DataAnnotations;
using CondoManager.Utils;
namespace CondoManager.Models
{
    public class Block : Entity
    {
        [Required(ErrorMessage = $"Nome {MessageUtil.IsRequired}")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        public virtual ICollection<Apartment>? ApartamentList { get; set; } = null;
        public int? CondoId { get; set; } = null;
        public virtual Condo? Condo { get; set; } = null;
    }
}