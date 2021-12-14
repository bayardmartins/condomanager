namespace CondoManager.Models
{
    public class User : Entity
    {
        public string UserName { get; set; }
        //mantendo publico e sem criptografia para simplicidade
        public string Password { get; set; }
        //mantendo string para simplicidade
        public string Role { get; set; }
    }
}