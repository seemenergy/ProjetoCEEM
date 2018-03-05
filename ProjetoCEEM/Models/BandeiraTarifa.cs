using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class BandeiraTarifa
    {
        [Key]
        public int Id { get; set; }
        public string Cor { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<DataHoraBandeiraTarifa> DataHoraBandeiraTarifa { get; set; }
    }
}
