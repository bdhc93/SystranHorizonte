using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class EmpleadoMap : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Telefono).IsOptional();
            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.Apellidos).IsRequired();
            this.Property(p => p.Cargo).IsRequired();
            this.Property(p => p.Comentario).IsOptional();
            this.Property(p => p.Estado).IsRequired();

            this.ToTable("Empleado");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Apellidos).HasColumnName("Apellidos");
            this.Property(c => c.Telefono).HasColumnName("Telefono");
            this.Property(c => c.Cargo).HasColumnName("Cargo");
            this.Property(c => c.Comentario).HasColumnName("Comentario");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}
