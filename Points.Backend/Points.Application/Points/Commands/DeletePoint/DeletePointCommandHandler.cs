using MediatR;
using Points.Application.Common.Exceptions;
using Points.Application.Interfaces;
using Points.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Points.Application.Points.Commands.DeletePoint
{
    public class DeletePointCommandHandler : IRequestHandler<DeletePointCommand>
    {
        private readonly IPointsDbContext _dbContext;

        public DeletePointCommandHandler(IPointsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeletePointCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Points
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Point), request.Id);
            }

            _dbContext.Points.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
