using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class VentaPasajeMap : EntityTypeConfiguration<VentaPasaje>
    {
        public VentaPasajeMap()
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

            this.Ignore(p => p.IdClienteTemp);
            this.Ignore(p => p.DniRucClienteTemp);
            this.Ignore(p => p.NombreClienteTemp);
            this.Ignore(p => p.ApellidosClienteTemp);
            this.Ignore(p => p.DireccionClienteTemp);
            this.Ignore(p => p.TelefonoClienteTemp);


            this.ToTable("VentaPasaje");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdHorario).HasColumnName("IdHorario");
            this.Property(c => c.IdCliente).HasColumnName("IdCliente");
            this.Property(c => c.IdCarga).HasColumnName("IdCarga");
            this.Property(c => c.IdVenta).HasColumnName("IdVenta");
            this.Property(c => c.Asiento).HasColumnName("Asiento");
            this.Property(c => c.Pago).HasColumnName("Pago");

            this.HasRequired(h => h.Horario)
                .WithMany(h => h.VentaPasajes)
                .HasForeignKey(p => p.IdHorario)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Cliente)
                .WithMany(h => h.VentaPasajes)
                .HasForeignKey(p => p.IdCliente)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Carga)
                .WithMany(h => h.VentaPasajes)
                .HasForeignKey(p => p.IdCarga)
                .WillCascadeOnDelete(false);

            this.HasOptional(h => h.Venta)
                .WithMany(h => h.VentaPasajes)
                .HasForeignKey(p => p.IdVenta)
                .WillCascadeOnDelete(true);
        }
    }
}
