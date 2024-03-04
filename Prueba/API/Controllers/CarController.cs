using Prueba.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.Infraestructure.Queries;
using Prueba.Infraestructure.Commands;

namespace Prueba.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("SearchCarByLocation")]
        public async Task<ActionResult> SearchCarByLocation([FromBody] SearchCarQuery query)
        {
            PetitionResponse res = await _mediator.Send(query);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpPost, Route("Create")]
        public async Task<ActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            PetitionResponse res = await _mediator.Send(command);
            if (res.Success)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
