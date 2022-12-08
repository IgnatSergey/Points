using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Points.Domain;

namespace Points.Persistence.EntityTypeConfigurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(point => point.Id);
            builder.HasIndex(point => point.Id).IsUnique();
        }
    }
}
