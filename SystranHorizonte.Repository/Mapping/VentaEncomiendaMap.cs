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

            this.Property(p => p.Fecha).IsRequired();
            this.Property(p => p.Pago).IsRequired();
            this.Property(p => p.Descripcion).IsRequired();

            this.Property(p => p.CargaEncomienda).IsOptional();

            this.ToTable("VentaEncomienda");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdHorario).HasColumnName("IdHorario");
            this.Property(c => c.IdCliente).HasColumnName("IdCliente");
            this.Property(c => c.IdCarga).HasColumnName("IdCarga");
            this.Property(c => c.IdVenta).HasColumnName("IdVenta");
            this.Property(c => c.Fecha).HasColumnName("Fecha");
            this.Property(c => c.Pago).HasColumnName("Pago");
            this.Property(c => c.Descripcion).HasColumnName("Descripcion");
            this.Property(c => c.CargaEncomienda).HasColumnName("CargaEncomienda");

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