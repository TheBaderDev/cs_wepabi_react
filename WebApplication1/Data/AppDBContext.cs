using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> context) : base(context) { }

        public DbSet<ObjectA> A { get; set; }

        public DbSet<ObjectB> B { get; set; }
    }
}
