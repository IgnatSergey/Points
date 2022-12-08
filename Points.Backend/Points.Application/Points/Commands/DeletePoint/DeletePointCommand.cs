using System;
using MediatR;

namespace Points.Application.Points.Commands.DeletePoint
{
    public class DeletePointCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
