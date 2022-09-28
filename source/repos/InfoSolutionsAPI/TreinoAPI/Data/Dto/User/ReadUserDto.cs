using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Data.Dto.User
{
    public class ReadUserDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Token { get; set; }
    }
}
