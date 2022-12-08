using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Points.Application.Interfaces;
using Points.Domain;

namespace Points.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommandHandler : IRequestHandler<CreatePointCommand, Guid>
    {
        private readonly IPointsDbContext _dbContext;

        public CreatePointCommandHandler(IPointsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreatePointCommand request,
            CancellationToken cancellationToken)
        {
            var point = new Point
            {
                PositionX = request.PositionX,
                PositionY = request.PositionY,
                Radius = request.Radius,
                Color = request.Color,
                Id = Guid.NewGuid(),
            };

            await _dbContext.Points.AddAsync(point, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return point.Id;
        }
    }
}
