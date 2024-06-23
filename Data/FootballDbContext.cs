using FootballLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.DataAccess
{
    public class FootballDbContext : DbContext
    {
        public DbSet<FootballTeam> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GNKQNCJ\\SQLEXPRESS;Database=FootballLeagueDb;Integrated Security=True;TrustServerCertificate=True;"); 
            }
        }
    }
}