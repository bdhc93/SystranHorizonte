using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class HorarioMap : EntityTypeConfiguration<Horario>
    {
        public HorarioMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.OrigenId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.DestinoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.EmpleadoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.Hora).IsRequired();
            this.Property(p => p.Asientos).IsRequired();
            this.Property(p => p.Estado).IsRequired();
            this.Property(p => p.Costo).IsRequired().HasPrecision(9, 2);
            this.Ignore(p => p.EstadoMostrar);
            this.Ignore(p => p.VehiculoId);
            this.Ignore(p => p.HoraText);
            this.Ignore(p => p.CostoText);

            this.Property(p => p.Asientos).IsRequired();

            this.ToTable("Horario");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.OrigenId).HasColumnName("OrigenId");
            this.Property(c => c.DestinoId).HasColumnName("DestinoId");
            this.Property(c => c.EmpleadoId).HasColumnName("EmpleadoId");
            this.Property(c => c.Asientos).HasColumnName("Asientos");
            this.Property(c => c.Hora).HasColumnName("Hora");
            this.Property(c => c.Costo).HasColumnName("Costo");
            this.Property(c => c.Estado).HasColumnName("Estado");

            this.HasRequired(h => h.EstacionOrigen)
                .WithMany(h => h.Horarios)
                .HasForeignKey(p => p.OrigenId)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.EstacionDestino)
                .WithMany(h => h.Horarioss)
                .HasForeignKey(p => p.DestinoId)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Empleados)
                .WithMany(h => h.Horarios)
                .HasForeignKey(p => p.EmpleadoId)
                .WillCascadeOnDelete(false);
        }
    }
}
