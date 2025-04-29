using Microsoft.EntityFrameworkCore;
using Class.Models;
using Microsoft.Extensions.Configuration;

namespace Class.Data
{
    public class BancoContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BancoContext(DbContextOptions<BancoContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Conecta ao SQLite
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}