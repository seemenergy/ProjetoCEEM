using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCEEM.Models
{
    public class PontoMedida
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataMedida { get; set; }
        public double MedidaCorrente { get; set; }
        public double MedidaTensao { get; set; }
        public int EquipamentoId { get; set; }
        //public int DataHoraBandeiraId { get; set; }
        //public virtual ICollection<DataHoraBandeira> DataHoraBandeira { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
}
