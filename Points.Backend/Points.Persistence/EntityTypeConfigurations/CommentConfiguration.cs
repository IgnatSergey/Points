using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Points.Domain;

namespace Points.Persistence.EntityTypeConfigurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(point => point.Id);
            builder.HasIndex(point => point.Id).IsUnique();
        }
    }
}
