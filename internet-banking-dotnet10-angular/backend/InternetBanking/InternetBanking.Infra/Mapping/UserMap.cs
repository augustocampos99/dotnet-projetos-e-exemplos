using InternetBanking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnName("cpf")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasColumnName("phone")
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address");

            builder.Property(e => e.MonthlyIncome)
                .HasColumnName("monthly_income")
                .IsRequired();

            builder.Property(e => e.Password)
                .HasColumnName("password");

            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }
    }
}
