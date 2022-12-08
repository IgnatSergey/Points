using MediatR;
using System;

namespace Points.Application.Points.Commands.CreatePoint
{
    public class CreatePointCommand : IRequest<Guid>
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Radius { get; set; }
        public string Color { get; set; }
    }
}
