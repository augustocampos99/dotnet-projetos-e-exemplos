using EmpresaAppCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Mapping
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("funcionarios");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.CPF)
                .HasColumnName("cpf")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(e => e.DepartamentoId)
                .HasColumnName("departamento_id")
                .IsRequired();

            builder.Property(e => e.Cargo)
                .HasColumnName("cargo_id")
                .IsRequired();

            builder.Ignore(e => e.Departamento);
            builder.Ignore(e => e.Cargo);

        }
    }
}
