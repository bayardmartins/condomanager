using System.ComponentModel.DataAnnotations;
using CondoManager.Utils;
namespace CondoManager.Models
{
    public class Resident : Entity
    {
        [Required(ErrorMessage = $"Nome {MessageUtil.IsRequired}")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = $"Data de nascimento {MessageUtil.IsRequired}")]
        [DataType(DataType.DateTime, ErrorMessage = $"Data de nascimento {MessageUtil.IsInvalid}")]
        public DateTime BirthDay { get; set; }
        
        [Required(ErrorMessage = $"Telefone {MessageUtil.IsRequired}")]
        [RegularExpression("(\\(?\\d{2}\\)?\\s)?(\\d{4,5}\\-\\d{4})", ErrorMessage = $"Telefone {MessageUtil.IsRequired}, verifique documentação para padrão aceito")]
        public string Phone { get; set; }
        
        //não faz cálculo de digito verificador, apenas quantidade de caracteres
        [Required(ErrorMessage = $"CPF {MessageUtil.IsRequired}")]
        [RegularExpression("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}", ErrorMessage = $"Telefone {MessageUtil.IsRequired}, verifique documentação para padrão aceito")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = $"E-mail {MessageUtil.IsRequired}")]
        [EmailAddress(ErrorMessage = $"E-mail {MessageUtil.IsRequired}")]
        public string Email { get; set; }
        public int? ApartmentId { get; set; } = null;
        public virtual Apartment? Apartments { get; set; } = null;
    }
}