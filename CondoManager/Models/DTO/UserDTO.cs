namespace CondoManager.Models.DTO
{
    public class UserDTO
    {
        public string? UserName { get; set; } = null;
        //mantendo publico e sem criptografia para simplicidade
        public string? Password { get; set; } = null;
        //mantendo string para simplicidade
        public string? Role { get; set; } = null;
    }
}