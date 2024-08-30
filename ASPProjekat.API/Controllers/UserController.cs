using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPProjekat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearchDto search,
                                [FromServices] IGetUsers query,
                                 [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserDto dto,
                                  [FromServices] IRegisterUser command,
                                  [FromServices] UseCaseHandler handler
)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
