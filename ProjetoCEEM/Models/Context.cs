using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoCEEM.Models
{
    public class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
        }

        public System.Data.Entity.DbSet<ProjetoCEEM.Models.Usuario> Usuarios { get; set; }
    }
}