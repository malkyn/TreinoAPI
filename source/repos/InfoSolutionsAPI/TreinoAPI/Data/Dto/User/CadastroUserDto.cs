using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Data.Dto.User
{
    public class CadastroUserDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Usuario é obrigatório")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "O campo Role é obrigatório")]
        public string Role { get; set; }
    }
}
