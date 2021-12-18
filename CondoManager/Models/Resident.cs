using System.ComponentModel.DataAnnotations;
namespace CondoManager.Models
{
    public class Resident : Entity
    {
        [Required(ErrorMessage = $"Nome é obrigatório")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = $"Data de nascimento é obrigatória")]
        [DataType(DataType.DateTime, ErrorMessage = $"Data de nascimento é inválida")]
        public DateTime BirthDay { get; set; }
        
        [Required(ErrorMessage = $"Telefone é obrigatório")]
        [RegularExpression("(\\(?\\d{2}\\)?\\s)?(\\d{4,5}\\-\\d{4})", ErrorMessage = $"Telefone inválid, verifique documentação para padrão aceito")]
        public string Phone { get; set; }
        
        //não faz cálculo de digito verificador, apenas quantidade de caracteres
        [Required(ErrorMessage = $"CPF é obrigatório")]
        [RegularExpression("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}", ErrorMessage = $"Telefone é obrigatório, verifique documentação para padrão aceito")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = $"E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = $"E-mail inválido")]
        public string Email { get; set; }
        public int? ApartmentId { get; set; } = null;
        public virtual Apartment? Apartments { get; set; } = null;
    }
}