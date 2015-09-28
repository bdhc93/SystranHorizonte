using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class EstacionesMap : EntityTypeConfiguration<Estacion>
    {
        public EstacionesMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Ciudad).IsRequired().HasMaxLength(75);
            this.Property(p => p.Provincia).IsRequired().HasMaxLength(75);
            this.Property(p => p.Direccion).IsRequired().HasMaxLength(50);
            this.Property(p => p.Telefono).IsRequired().HasMaxLength(15);

            this.Ignore(p => p.EstacionesT);

            this.Property(p => p.Estado).IsRequired();
            this.Ignore(p => p.EstadoMostrar);

            this.ToTable("Estacion");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Ciudad).HasColumnName("Ciudad");
            this.Property(c => c.Provincia).HasColumnName("Provincia");
            this.Property(c => c.Direccion).HasColumnName("Direccion");
            this.Property(c => c.Telefono).HasColumnName("Telefono");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}