using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Ativos
{
    public class CriptoMoeda
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Saldo { get; set; }
    }
}
