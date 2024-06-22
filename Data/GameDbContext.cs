using Microsoft.EntityFrameworkCore;
using ClassLibrary;

namespace DataAccess
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GNKQNCJ\\SQLEXPRESS;Database=GameLibrary;Integrated Security=True;");
        }
    }
}