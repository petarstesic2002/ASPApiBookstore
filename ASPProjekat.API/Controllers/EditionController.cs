using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.ApplicationLayer.DTO;
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
        // POST api/<EditionController>
        [HttpPost]
        public IActionResult PostEdition([FromBody] CreateEditionDto dto,
                                  [FromServices] ICreateEdition command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
        // PUT api/<BooksController>
        [HttpPut]
        public void PutEdition([FromBody] UpdateEditionDto dto, [FromServices] IUpdateEdition command, [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, dto);
        }
    }
}
