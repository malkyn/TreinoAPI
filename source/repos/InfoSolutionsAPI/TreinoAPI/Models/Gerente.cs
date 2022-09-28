using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreinoAPI.Models
{
    public class Gerente : User
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
