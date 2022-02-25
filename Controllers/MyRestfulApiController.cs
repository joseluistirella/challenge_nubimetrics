using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MediatR;

using Service.Queries;

namespace ml.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyRestfulApiController : ControllerBase
    {

        private readonly ILogger<MyRestfulApiController> _logger;
        //private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MyRestfulApiController(ILogger<MyRestfulApiController> logger, IMediator mediator)
        {
            _logger = logger;
            //_mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("Paises/{pais}")]
        public async Task<IActionResult> Get(string pais)
        {
            GetCountry query = new(pais);
            Country result = await _mediator.Send(query);

            return Ok(result);
        }
        
        [HttpGet("busqueda/{queryArgument}")]
        public async Task<IActionResult> Search(string queryArgument)
        {
            SearchItems searchItems = new(queryArgument);
            Search response = await _mediator.Send(searchItems);

            if (response.results.Count == 0)
            {
                return NoContent();
            }

            List<Found> results = this.prepareResult(response.results);
            return Ok(results);
        }

        private List<Found> prepareResult(List<Result> items)
        {
            List<Found> results = new();

            foreach (Result item in items)
            {
                results.Add(
                    new Found(
                        item.id,
                        item.site_id,
                        item.title,
                        item.price,
                        item.seller.id,
                        item.permalink
                    )
                );
            }

            return results;
        }
        
        [HttpGet("currencies/generate/")]
        public async Task<IActionResult> CurrencyGenerate()
        {
            string response = await _mediator.Send(new CurrenciesConvertions());
            return Ok(response);
        }

        [HttpGet("status")]
        public IActionResult Get()
        {
            return Ok("Is Ready!");
        }
    }
}
