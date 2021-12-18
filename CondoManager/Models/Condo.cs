using System.ComponentModel.DataAnnotations;
using CondoManager.Utils;

namespace CondoManager.Models
{
    public class Condo : Entity
    {
        [Required(ErrorMessage = $"Nome {MessageUtil.IsRequired}")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = $"Telefone {MessageUtil.IsRequired}")]
        [RegularExpression("(\\(?\\d{2}\\)?\\s)?(\\d{4,5}\\-\\d{4})", ErrorMessage = $"Telefone {MessageUtil.IsRequired}, verifique documentação para padrão aceito")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = $"E-mail do Síndico {MessageUtil.IsRequired}")]
        [EmailAddress(ErrorMessage = $"E-mail {MessageUtil.IsRequired}")]
        public string ManagerEmail { get; set; }
        
        public virtual ICollection<Block>? BlockList { get;set; } = null;
    }
}