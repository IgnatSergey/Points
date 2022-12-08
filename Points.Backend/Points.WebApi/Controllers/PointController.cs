using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Points.Application.Points.Queries.GetAllPoints;
using Points.Application.Points.Commands.DeletePoint;

namespace Points.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PointController : BaseController
    {
        private readonly IMapper _mapper;

        public PointController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PointListVm>> GetAll()
        {
            var query = new GetAllPointsQuery { };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePointCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
