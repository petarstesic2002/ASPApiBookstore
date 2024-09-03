using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.DataAccess;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ASPContext _context;

        public BooksController(ASPContext context)
        {
            _context = context;
        }

        // GET api<BooksController>
        [HttpGet]
        public IActionResult Get([FromQuery] UniqueBookSearchDto dto, [FromServices] IGetUniqueBooks query, [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, dto));
        }
        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookDto dto,
                                  [FromServices] ICreateBook command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command,dto);
            return StatusCode(201);
        }
        // PUT api/<BooksController>
        [HttpPut]
        public void Put([FromBody] UpdateBookDto dto, [FromServices] IUpdateBook command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command,dto);
        }
        // DELETE api<BooksController>
        [HttpDelete]
        public void Delete([FromBody] int id, [FromServices] IDeleteBook command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command,id);
        }
    }
}
