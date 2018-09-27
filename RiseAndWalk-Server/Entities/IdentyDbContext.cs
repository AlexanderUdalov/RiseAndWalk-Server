using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RiseAndWalk_Server.Entities
{
    public class IdentyDbContext : IdentityDbContext
    {
        public IdentyDbContext(DbContextOptions<IdentyDbContext> options) : base(options) { }
    }
}