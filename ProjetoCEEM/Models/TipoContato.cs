using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class TipoContato
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Contato> Contato { get; set; }
    }
}
