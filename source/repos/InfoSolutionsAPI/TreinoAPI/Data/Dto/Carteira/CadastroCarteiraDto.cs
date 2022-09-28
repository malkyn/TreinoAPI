using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Data.Dto.Carteira
{
    public class CadastroCarteiraDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
