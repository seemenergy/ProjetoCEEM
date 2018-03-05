using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class DataHoraBandeira
    {
        [Key]
        public int Id { get; set; }
        public Boolean Verao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public virtual ICollection<PontoMedida> PontoMedida { get; set; }
        public virtual ICollection<DataHoraBandeiraTarifa> DataHoraBandeiraTarifa { get; set; }
    }
}
