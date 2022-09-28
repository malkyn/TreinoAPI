using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Models
{
    public class Cliente : User
    {
        [Key]
        public int Id { get; set; }
        public int GerenteId { get; set; }
        public virtual Gerente Gerente { get; set; }
    }
}
