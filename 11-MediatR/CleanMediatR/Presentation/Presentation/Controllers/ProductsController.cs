using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Application.Requests;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
            => Ok(await _mediator.Send(new GetAllProductQuery()));

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<string>> CreateProduct([FromBody] CreateProductRequest request)
            => Ok(await _mediator.Send(new CreateProductCommand(request.Id, request.Name, request.Price)));
    }
}
