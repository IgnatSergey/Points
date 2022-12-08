using Microsoft.EntityFrameworkCore;
using Points.Application.Interfaces;
using Points.Domain;
using Points.Persistence.EntityTypeConfigurations;

namespace Points.Persistence
{
    public class PointsDbContext : DbContext, IPointsDbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public PointsDbContext(DbContextOptions<PointsDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PointConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.Entity<Comment>()
            .HasOne(c => c.Point)
            .WithMany(p => p.Comments)
            .OnDelete(DeleteBehavior.Cascade); ;
            base.OnModelCreating(builder);
        }
    }
}
