using ExemploContatosApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploContatosApp.Data
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }
        public PostgreSQLContext() { }

        public DbSet<Contato> Contatos { get; set; }
    }
}
