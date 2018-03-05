using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCEEM.Models
{
    public class DataHoraBandeiraTarifa
    {
        [Key,Column(Order = 0)]
        public int DataHoraBandeiraId { get; set; }
        [Key, Column(Order = 1)]
        public int BandeiraTarifaId { get; set; }
    }
}
