using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.DniRuc).IsRequired();
            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.Apellidos).IsOptional();
            this.Property(p => p.Direccion).IsOptional();
            this.Property(p => p.Telefono).IsOptional();


            this.ToTable("Cliente");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.DniRuc).HasColumnName("DniRuc");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Apellidos).HasColumnName("Apellidos");
            this.Property(c => c.Direccion).HasColumnName("Direccion");
            this.Property(c => c.Telefono).HasColumnName("Telefono");
        }
    }
}