using BackendOncologia.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackendOncologia.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<PreQuimio> PreQuimio { get; set; }

        public DbSet<ViaDeAdministracao> ViaDeAdministracao { get; set; }
        public DbSet<TipoPreQuimio> TipoPreQuimio { get; set; }
        public DbSet<MedicacaoPreQuimio> MedicacaoPreQuimio { get; set; }
        public DbSet<DescricaoProtocolo> DescricaoProtocolos { get; set; }
        public DbSet<Protocolos> Protocolos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
