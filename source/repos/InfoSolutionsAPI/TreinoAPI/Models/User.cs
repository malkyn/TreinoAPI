using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Role { get; set; }
        public string Token { get; set; }
        public virtual Carteira Carteira{ get; set; }
        public string UsuarioNaoExistente { get; set; }
    }
}
