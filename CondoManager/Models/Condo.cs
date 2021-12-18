using System.ComponentModel.DataAnnotations;

namespace CondoManager.Models
{
    public class Condo : Entity
    {
        [Required(ErrorMessage = $"Nome é obrigatório")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = $"Telefone é obrigatório")]
        [RegularExpression("(\\(?\\d{2}\\)?\\s)?(\\d{4,5}\\-\\d{4})", ErrorMessage = $"Telefone é obrigatório, verifique documentação para padrão aceito")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = $"E-mail do Síndico é obrigatório")]
        [EmailAddress(ErrorMessage = $"E-mail é obrigatório")]
        public string ManagerEmail { get; set; }
        
        public virtual ICollection<Block>? BlockList { get;set; } = null;
    }
}