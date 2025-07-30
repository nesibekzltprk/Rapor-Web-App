using Microsoft.EntityFrameworkCore;
using RaporFront.Models;

namespace RaporFront.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options)
            : base(options)
        {
        }

        // DbSet örneği:
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<RaporTaslak> RaporTaslaklari { get; set; }
    }
}
