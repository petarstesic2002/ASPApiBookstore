using ASPProjekat.API.DTO;
using ASPProjekat.ApplicationLayer.Commands;
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
    public class EditionController : ControllerBase
    {
        private ASPContext _context;

        public EditionController(ASPContext context)
        {
            _context = context;
        }
        // GET: api/<EditionController>
        [HttpGet]
        public IActionResult Get([FromQuery] BookSearchDto search,
                                [FromServices] IGetBooks query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }
        // POST api/<EditionController>
        [HttpPost]
        public IActionResult PostEdition(
                                  [FromForm] CreateEditionDto dto,
                                  [FromServices] ICreateEdition command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // PUT api/<BooksController>
        [HttpPut]
        public void PutEdition([FromForm] UpdateEditionDto dto, [FromServices] IUpdateEdition command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, dto);
        }
        // DELETE api/<BooksController>
        [HttpDelete]
        public void DeleteEdition([FromBody] int editionId, [FromServices] IDeleteEdition command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, editionId);
        }
    }
}
