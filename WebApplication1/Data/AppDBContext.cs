using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> context) : base(context) {
            
        }

        public DbSet<ObjectA> A { get; set; }

        public DbSet<ObjectB> B { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship and set delete behavior to SetNull
            modelBuilder.Entity<ObjectB>()
                .HasOne(b => b.ObjectA)
                .WithMany(a => a.ObjectBs)
                .HasForeignKey(b => b.ObjectAId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
