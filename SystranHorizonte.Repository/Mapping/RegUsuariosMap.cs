using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class RegUsuariosMap : EntityTypeConfiguration<RegUsuarios>
    {
        public RegUsuariosMap()
        {
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Usuario).IsRequired();
            this.Property(p => p.Modulo).IsRequired();
            this.Property(p => p.Cambio).IsRequired();
            this.Property(p => p.IdModulo).IsRequired();
            
            this.ToTable("RegUsuarios");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Usuario).HasColumnName("Usuario");
            this.Property(c => c.Cambio).HasColumnName("Cambio");
            this.Property(c => c.IdModulo).HasColumnName("IdModulo");
            this.Property(c => c.Modulo).HasColumnName("Modulo");
        }
    }
}
