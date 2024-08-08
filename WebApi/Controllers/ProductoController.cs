using Domain.Commands;
using Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get(int? id, string? nombre)
        {
            var data = await _mediator.Send(new ListarProductoQuery(id, nombre));
            return Ok(data);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CrearProductoCommand request)
        {
            var data = await _mediator.Send(request);
            return Ok(data);
        }
    }
}
