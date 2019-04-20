using System.Data.Entity;

using PlayerLoto.Domain;

namespace PlayerLoto.DataEF
{
    public class PlayerLotoContext : DbContext
    {
        public PlayerLotoContext() : base("DefaultConnection")
        {

        }

        public DbSet<DrawingResult> DrawingResults { get; set; }
        public DbSet<Cabala_Number> Cabala_Numero { get; set; }
        public DbSet<Cabala_Word> Cabala_Palabra { get; set; }

    }
}
