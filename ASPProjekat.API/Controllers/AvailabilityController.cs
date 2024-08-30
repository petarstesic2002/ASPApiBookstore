using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.DataAccess;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private ASPContext _context;

        public AvailabilityController(ASPContext context) { 
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAvailable([FromQuery] BookAvailabilitySearchDto search,
                                [FromServices] ICheckBookAvailability query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }
    }
}
