using Microsoft.EntityFrameworkCore;
namespace FrankyFinance.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<GastoCompartido> GastosCompartidos { get; set; }
        public DbSet<MiembroGrupo> MiembrosGrupos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MiembroGrupo>().HasKey(mg => new { mg.UsuarioId, mg.GrupoId });
            modelBuilder.Entity<GastoCompartido>().HasKey(gc => new { gc.UsuarioId, gc.GastoId });
        }
    }
}
