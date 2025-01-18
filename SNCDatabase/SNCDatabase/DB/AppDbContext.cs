using Microsoft.EntityFrameworkCore;
using SNCDatabase.Models;

namespace SNCDatabase.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admini { get; set; }
        public DbSet<Dekorater> Dekorateri { get; set; }
        public DbSet<Fotograf> Fotografi { get; set; }
        public DbSet<Gosti> Gosti { get; set; }
        public DbSet<Jelovnik> Jelovnici { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<MailCuvanje> MailCuvanje { get; set; }
        public DbSet<Mladenci> Mladenci { get; set; }
        public DbSet<OceneDekorater> OceneDekorateri { get; set; }
        public DbSet<OceneFotograf> OceneFotografi{ get; set; }
        public DbSet<OcenePoslasticar> OcenePoslasticari{ get; set; }
        public DbSet<OceneRestoran> OceneRestorani { get; set; }
        public DbSet<Poslasticar> Poslasticari { get; set; }
        public DbSet<Restoran> Restorani { get; set; }
        public DbSet<SacuvanDekorater> SacuvaniDekorateri { get; set; }
        public DbSet<SacuvanFotograf> SacuvaniFotografi { get; set; }
        public DbSet<SacuvanPoslasticar> SacuvaniPoslasticari{ get; set; }
        public DbSet<SacuvanRestoran> SacuvaniRestorani { get; set; }
        public DbSet<SigurnosniKod> SigurnosniKodovi { get; set; }
        public DbSet<SlikeDekorater> SlikeDekoratera { get; set; }
        public DbSet<SlikeFotograf> SlikeFotografa { get; set; }
        public DbSet<SlikePoslasticar> SlikePoslasticara { get; set; }
        public DbSet<SlikeRestoran> SlikeRestorana { get; set; }
        public DbSet<SlobodanTermin> SlobodniTermini { get; set; }
        public DbSet<ZakazanJelovnik> ZakazaniJelovnici { get; set; }
        public DbSet<Zakazano> Zakazano { get; set; }

    }
}
