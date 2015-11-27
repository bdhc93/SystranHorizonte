using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Usuario).IsRequired();
            this.Property(p => p.Contrasenia).IsRequired();
            this.Property(p => p.Email).IsOptional();
            this.Property(p => p.Recuerdame).IsRequired();
            this.Property(p => p.Nombre).IsOptional();
            this.Property(p => p.Apellidos).IsOptional();
            this.Property(p => p.Telefono).IsOptional();

            this.ToTable("UserAccount");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Usuario).HasColumnName("Usuario");
            this.Property(c => c.Contrasenia).HasColumnName("Contrasenia");
            this.Property(c => c.Email).HasColumnName("Email");
            this.Property(c => c.Recuerdame).HasColumnName("Recuerdame");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Apellidos).HasColumnName("Apellidos");
            this.Property(c => c.Telefono).HasColumnName("Telefono");
        }
    }
}
