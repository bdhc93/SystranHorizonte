using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class VentaEncomiendaMap : EntityTypeConfiguration<VentaEncomienda>
    {
        public VentaEncomiendaMap()
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
            
            this.Property(p => p.Pago).IsRequired();
            this.Property(p => p.Descripcion).IsRequired();
            this.Property(p => p.Estado).IsRequired();
            this.Property(p => p.FechaRecepcion).IsRequired();

            this.Ignore(p => p.IdClienteTemp);
            this.Ignore(p => p.DniRucClienteTemp);
            this.Ignore(p => p.NombreClienteTemp);
            this.Ignore(p => p.ApellidosClienteTemp);
            this.Ignore(p => p.DireccionClienteTemp);
            this.Ignore(p => p.TelefonoClienteTemp);
            this.Ignore(p => p.EstadoMostrar);
            this.Ignore(p => p.FechaRecepcionText);

            this.Property(p => p.CargaEncomienda).IsOptional();

            this.ToTable("VentaEncomienda");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdHorario).HasColumnName("IdHorario");
            this.Property(c => c.IdCliente).HasColumnName("IdCliente");
            this.Property(c => c.IdCarga).HasColumnName("IdCarga");
            this.Property(c => c.IdVenta).HasColumnName("IdVenta");
            this.Property(c => c.FechaRecepcion).HasColumnName("FechaRecepcion");
            this.Property(c => c.Pago).HasColumnName("Pago");
            this.Property(c => c.Descripcion).HasColumnName("Descripcion");
            this.Property(c => c.CargaEncomienda).HasColumnName("CargaEncomienda");
            this.Property(c => c.Estado).HasColumnName("Estado");

            this.HasRequired(h => h.Horario)
                .WithMany(h => h.VentaEncomiendas)
                .HasForeignKey(p => p.IdHorario)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Cliente)
                .WithMany(h => h.VentaEncomiendas)
                .HasForeignKey(p => p.IdCliente)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Carga)
                .WithMany(h => h.VentaEncomiendas)
                .HasForeignKey(p => p.IdCarga)
                .WillCascadeOnDelete(false);

            this.HasOptional(h => h.Venta)
                .WithMany(h => h.VentaEncomiendas)
                .HasForeignKey(p => p.IdVenta)
                .WillCascadeOnDelete(true);
        }
    }
}