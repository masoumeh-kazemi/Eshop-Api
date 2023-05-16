using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Query.Categories.GetById;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/test")]
        public async Task<IActionResult> GetOrder()
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(1));
            return Ok(result);
        }

    }
}