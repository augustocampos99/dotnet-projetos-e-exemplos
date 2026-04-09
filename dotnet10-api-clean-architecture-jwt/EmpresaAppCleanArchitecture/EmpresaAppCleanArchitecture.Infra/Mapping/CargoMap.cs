using EmpresaAppCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Mapping
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .IsRequired();
        }
    }
}
