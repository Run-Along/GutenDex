using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using GutenDexAPI.Models;

namespace GutenDexAPI.Models
{
    public class GutenDexAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public GutenDexAPIDBContext(DbContextOptions<GutenDexAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("GutenDex");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Author> Authors {get; set;} = null!;
        public DbSet<Book> Books { get; set; } = null!;
    }
}
