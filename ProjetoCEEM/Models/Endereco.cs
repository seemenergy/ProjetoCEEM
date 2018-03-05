using System.ComponentModel.DataAnnotations;

namespace ProjetoCEEM.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public char Status { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
