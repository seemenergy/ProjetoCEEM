using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public virtual Usuario Usuario { get; set; }

        public bool PodeCadastrarPontos(Context db)
        {
            if (db.PontoMedidas.Count(p => p.EquipamentoId == Id) < QuantPontoMax)
                return true;
            return false;
        }

    }
}
