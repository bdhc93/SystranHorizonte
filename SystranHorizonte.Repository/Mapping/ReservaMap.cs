using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class ReservaMap : EntityTypeConfiguration<Reserva>
    {
        public ReservaMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdHorario)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdCarga)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdVenta)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.Asiento).IsOptional();
            this.Property(p => p.Pago).IsOptional();
            this.Property(p => p.ACuenta).IsOptional();


            this.ToTable("Reserva");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdHorario).HasColumnName("IdHorario");
            this.Property(c => c.IdCliente).HasColumnName("IdCliente");
            this.Property(c => c.IdCarga).HasColumnName("IdCarga");
            this.Property(c => c.IdVenta).HasColumnName("IdVenta");
            this.Property(c => c.Asiento).HasColumnName("Asiento");
            this.Property(c => c.Pago).HasColumnName("Pago");
            this.Property(c => c.ACuenta).HasColumnName("ACuenta");

            this.HasRequired(h => h.Horario)
                .WithMany(h => h.Reservas)
                .HasForeignKey(p => p.IdHorario)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Cliente)
                .WithMany(h => h.Reservas)
                .HasForeignKey(p => p.IdCliente)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Carga)
                .WithMany(h => h.Reservas)
                .HasForeignKey(p => p.IdCarga)
                .WillCascadeOnDelete(false);

            this.HasOptional(h => h.Venta)
                .WithMany(h => h.Reseras)
                .HasForeignKey(p => p.IdVenta)
                .WillCascadeOnDelete(true);
        }
    }
}
