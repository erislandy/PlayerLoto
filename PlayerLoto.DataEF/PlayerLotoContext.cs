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
    }
}
