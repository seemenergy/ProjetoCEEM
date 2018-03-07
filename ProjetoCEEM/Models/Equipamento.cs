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

        public int QuantPontosDisponiveis(Context db)
        {
            return (QuantPontoMax - db.PontoMedidas.Count(p => p.EquipamentoId == Id));
        }
        public int QuantPontos(Context db)
        {
            return db.PontoMedidas.Count(p => p.EquipamentoId == Id);
        }
    }
}
