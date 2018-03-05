using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoContatoId { get; set; }
        public string Descricao { get; set; }
        public char Status { get; set; }
        public virtual TipoContato TipoContato { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
