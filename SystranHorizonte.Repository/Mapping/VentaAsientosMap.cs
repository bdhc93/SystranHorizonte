using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class VentaAsientosMap : EntityTypeConfiguration<VentaAsientos>
    {
        public VentaAsientosMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdHorario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdVehiculo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.Asiento).IsRequired();
            this.Property(p => p.Libre).IsRequired();
            this.Property(p => p.Fecha).IsRequired();

            this.ToTable("VentaAsientos");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdHorario).HasColumnName("IdHorario");
            this.Property(c => c.IdVehiculo).HasColumnName("IdVehiculo");
            this.Property(c => c.Asiento).HasColumnName("Asiento");
            this.Property(c => c.Libre).HasColumnName("Libre");
            this.Property(c => c.Fecha).HasColumnName("Fecha");

            this.HasRequired(h => h.Horario)
                .WithMany(h => h.VentaAsientoss)
                .HasForeignKey(p => p.IdHorario)
                .WillCascadeOnDelete(true);

            this.HasRequired(h => h.Vehiculo)
                .WithMany(h => h.VentaAsientoss)
                .HasForeignKey(p => p.IdVehiculo)
                .WillCascadeOnDelete(false);
        }
    }
}