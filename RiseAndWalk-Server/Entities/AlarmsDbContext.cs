using Microsoft.EntityFrameworkCore;
using RiseAndWalk_Server.Models;
using System;

namespace RiseAndWalk_Server.Entities
{
    public class AlarmsDbContext : DbContext
    {
        public DbSet<AlarmEntity> Alarms { get; set; }

        public AlarmsDbContext(DbContextOptions<AlarmsDbContext> options) : base(options) { }
    }
}
