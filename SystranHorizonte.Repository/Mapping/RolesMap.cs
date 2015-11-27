﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Mapping
{
    public class RolesMap : EntityTypeConfiguration<Roles>
    {
        public RolesMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.Comentario).IsOptional();
            
            this.ToTable("UserRoles");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Comentario).HasColumnName("Comentario");
        }
    }
}