using TreinoAPI.Ativos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Models
{
    public class Ativo
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual List<Acao> Acoes { get; set; }
        public virtual List<Fundo> Fundos { get; set; }
        public virtual List<CriptoMoeda> CriptoMoedas { get; set; }
        public virtual Carteira Carteira { get; set; }
        public int CarteiraId { get; set; }

    }
}