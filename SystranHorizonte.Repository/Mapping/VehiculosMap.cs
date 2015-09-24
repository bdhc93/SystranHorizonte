using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class VehiculosMap : EntityTypeConfiguration<Vehiculo>
    {
        public VehiculosMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.TarjetaPropiedad).IsRequired();
            this.Property(p => p.NroPlaca).IsRequired();
            this.Property(p => p.FechaSoat).IsOptional();
            this.Property(p => p.FechaSoatFin).IsOptional();
            this.Property(p => p.FechaRevisionTecnica).IsOptional();
            this.Property(p => p.FechaRevisionTecnicaFin).IsOptional();
            this.Property(p => p.Ancho).IsOptional();
            this.Property(p => p.Largo).IsOptional();
            this.Property(p => p.Asientos).IsRequired();
            this.Property(p => p.Tipo).IsRequired();
            this.Property(p => p.Estado).IsRequired();


            this.ToTable("Vehiculo");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.TarjetaPropiedad).HasColumnName("TarjetaPropiedad");
            this.Property(c => c.NroPlaca).HasColumnName("NroPlaca");
            this.Property(c => c.FechaSoat).HasColumnName("FechaSoat");
            this.Property(c => c.FechaSoatFin).HasColumnName("FechaSoatFin");
            this.Property(c => c.FechaRevisionTecnica).HasColumnName("FechaRevisionTecnica");
            this.Property(c => c.FechaRevisionTecnicaFin).HasColumnName("FechaRevisionTecnicaFin");
            this.Property(c => c.Ancho).HasColumnName("Ancho");
            this.Property(c => c.Largo).HasColumnName("Largo");
            this.Property(c => c.Asientos).HasColumnName("Asientos");
            this.Property(c => c.Tipo).HasColumnName("Tipo");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}
