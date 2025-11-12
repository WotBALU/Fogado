using Microsoft.EntityFrameworkCore;
using Fogado.Models;


namespace Fogado.Data
{
    public class FogadoContext : DbContext
    {
        public FogadoContext(DbContextOptions<FogadoContext> options) : base(options) { }
        public DbSet<Szoba> Szobak {  get; set; }
        public DbSet<Vendeg> Vendegek { get; set; }
        public DbSet<Foglalas> Foglalasok { get; set; }
    }
}
