using Microsoft.EntityFrameworkCore;

namespace RiseAndWalk_Server.Entities
{
    public class AlarmsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=alarms_database;Trusted_Connection=True;");
        }
    }
}
