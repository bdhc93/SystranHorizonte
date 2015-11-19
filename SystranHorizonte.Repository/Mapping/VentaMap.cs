using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class VentaMap : EntityTypeConfiguration<Venta>
    {
        public VentaMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdCliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.Fecha).IsRequired();
            this.Property(p => p.NroVenta).IsRequired();
            this.Property(p => p.Tipo).IsRequired();
            this.Property(p => p.Estado).IsRequired();
            this.Property(p => p.TotalVenta).IsRequired().HasPrecision(9, 2);

            this.Ignore(p => p.RucDniCliente);

            this.ToTable("Venta");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdCliente).HasColumnName("IdCliente");
            this.Property(c => c.Fecha).HasColumnName("Fecha");
            this.Property(c => c.NroVenta).HasColumnName("NroVenta");
            this.Property(c => c.Estado).HasColumnName("Estado");
            this.Property(c => c.Tipo).HasColumnName("Tipo");
            this.Property(c => c.TotalVenta).HasColumnName("TotalVenta");

            this.HasRequired(h => h.Cliente)
                .WithMany(h => h.Ventas)
                .HasForeignKey(p => p.IdCliente)
                .WillCascadeOnDelete(false);
        }
    }
}
