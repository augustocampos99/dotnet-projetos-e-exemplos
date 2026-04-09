using EmpresaAppCleanArchitecture.Domain.Entities;
using EmpresaAppCleanArchitecture.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Infra.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }
        public PostgreSQLContext() { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}
