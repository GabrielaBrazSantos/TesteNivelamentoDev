using Microsoft.EntityFrameworkCore;
using Questao5.Entities;

namespace Questao5.Infrastructure.Database
{
    public partial class Context : DbContext
    {
        public DbSet<Idempotencia> Idempotencia { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlite(connectionString: "DataSource=database.sqlite;Cache=Shared");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
