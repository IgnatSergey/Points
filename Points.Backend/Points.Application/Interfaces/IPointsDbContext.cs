using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Points.Domain;

namespace Points.Application.Interfaces
{
    public interface IPointsDbContext
    {
        DbSet<Point> Points { get; set; }
        DbSet<Comment> Comments { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
