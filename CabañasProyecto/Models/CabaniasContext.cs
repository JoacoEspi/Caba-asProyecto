using Microsoft.EntityFrameworkCore;

namespace CabañasProyecto.Models
{
    public class CabaniasContext : DbContext
    {
        
        // Preguntar si esto va asi
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source=.; Initial Catalog=Ventas; Integrated Security = true");
        }

        #region DbSets

        public DbSet<Cabania> Cabanias { get; set; } 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Login> Login { get; set; }
        #endregion
    }
}
