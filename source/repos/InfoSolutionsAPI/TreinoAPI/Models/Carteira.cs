using TreinoAPI.Ativos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TreinoAPI.Models
{
    public class Carteira
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int Saldo
        {
            get
            {
                int fundos  = Ativos?.Fundos?.Aggregate(0, (x, y) => x += y.Saldo)?? 0;
                int acoes = Ativos?.Acoes?.Aggregate(0, (x, y) => x += y.Saldo)?? 0;
                int criptomoedas = Ativos?.CriptoMoedas?.Aggregate(0, (x, y) => x += y.Saldo)?? 0;

                int soma = fundos + acoes + criptomoedas;
                return soma;
            }
        }
        public int UserId { get; set; }
        public virtual Ativo Ativos { get; set; }
        public virtual User User { get; set; }
    }
}