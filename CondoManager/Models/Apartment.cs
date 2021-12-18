using System.ComponentModel.DataAnnotations;

namespace CondoManager.Models
{
    public class Apartment : Entity
    {
        //usando string ao invés de int para possíveis regras de negócio, como apartamento 001
        [Required(ErrorMessage = "Número é obrigatório")]
        [DataType(DataType.Text)]
        public string Number { get; set; }

        [Required(ErrorMessage = "Andar é obrigatório")]
        public int Floor { get ; set; }
        public List<Resident>? ResidentList { get; set; } = null;
        public int? BlockId { get; set; }
        public virtual Block? Block { get; set; } = null;
    }
}