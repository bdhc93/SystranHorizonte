using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class DetalleUsuarioMap : EntityTypeConfiguration<DetalleUsuario>
    {
        public DetalleUsuarioMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdAccount)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdRol)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            this.ToTable("UserDetalleUsuario");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdAccount).HasColumnName("IdAccount");
            this.Property(c => c.IdRol).HasColumnName("IdRol");

            this.HasRequired(h => h.Account)
                .WithMany(h => h.DetalleUsuarios)
                .HasForeignKey(p => p.IdAccount)
                .WillCascadeOnDelete(false);


            this.HasRequired(h => h.Roles)
                .WithMany(h => h.DetalleUsuarios)
                .HasForeignKey(p => p.IdRol)
                .WillCascadeOnDelete(false);
        }
    }
}
