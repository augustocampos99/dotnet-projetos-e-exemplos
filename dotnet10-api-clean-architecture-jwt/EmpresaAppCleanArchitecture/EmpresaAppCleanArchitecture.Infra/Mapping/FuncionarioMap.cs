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

            builder.Property(e => e.CargoId)
                .HasColumnName("cargo_id")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.DataCriacao)
                .HasColumnName("data_criacao")
                .IsRequired();

            builder.Property(e => e.DataAtualizacao)
                .HasColumnName("data_atualizacao")
                .IsRequired();

            builder.Ignore(e => e.Departamento);
            builder.Ignore(e => e.Cargo);

            builder.HasOne(e => e.Departamento)
                .WithMany()
                .HasForeignKey(e => e.DepartamentoId);

            builder.HasOne(e => e.Cargo)
                .WithMany()
                .HasForeignKey(e => e.CargoId);

        }
    }
}
