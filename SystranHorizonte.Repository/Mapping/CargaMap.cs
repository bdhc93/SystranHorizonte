using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class CargaMap : EntityTypeConfiguration<Carga>
    {
        public CargaMap()
        {
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Peso).IsRequired();
            this.Property(p => p.Precio).IsRequired().HasPrecision(9, 2);
            this.Property(p => p.Tipo).IsRequired();
            this.Property(p => p.Estado).IsRequired();

            this.Ignore(p => p.TipoMostrar);
            this.Ignore(p => p.TipoString);
            this.Ignore(p => p.EstadoMostrar);
            this.Ignore(p => p.PrecioText);

            this.ToTable("Carga");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Peso).HasColumnName("Peso");
            this.Property(c => c.Precio).HasColumnName("Precio");
            this.Property(c => c.Tipo).HasColumnName("Tipo");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}