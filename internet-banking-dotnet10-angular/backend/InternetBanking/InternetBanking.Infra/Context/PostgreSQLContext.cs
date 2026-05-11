using InternetBanking.Domain.Entities;
using InternetBanking.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Infra.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {            
        }
        public PostgreSQLContext()
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public DbSet<User> Users { get; set; }
    }
}
