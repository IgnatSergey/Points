using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Points.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Points.Application.Points.Queries.GetAllPoints
{
    public class GetAllPointsQueryHandler : IRequestHandler<GetAllPointsQuery, PointListVm>
    {
        private readonly IPointsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllPointsQueryHandler(IPointsDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PointListVm> Handle(GetAllPointsQuery request,
            CancellationToken cancellationToken)
        {
            var pointsQuery = await _dbContext.Points
                .ProjectTo<PointLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PointListVm { Points = pointsQuery };
        }
    }
}
