namespace CondoManager.Models
{
    public class Resident : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int? ApartmentId { get; set; } = null;
        public virtual Apartment? Apartments { get; set; } = null;
    }
}