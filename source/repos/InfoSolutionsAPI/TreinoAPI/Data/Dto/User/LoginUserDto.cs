using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Data.Dto.User
{
    public class LoginUserDto
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
