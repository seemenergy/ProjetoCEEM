using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class Equipamento
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int QuantPontoMax { get; set; }
        public virtual ICollection<PontoMedida> PontoMedida { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
