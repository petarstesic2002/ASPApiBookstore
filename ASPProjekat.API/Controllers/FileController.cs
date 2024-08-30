using ASPProjekat.API.DTO;
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
    public class FileController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] FileUploadDto dto, [FromServices] ASPContext context)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.File.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.File.CopyTo(fileStream);
            }
            context.Images.Add(new DomainLayer.Entities.Image
            {
                Path=newFileName
            });
            context.SaveChanges();

            return StatusCode(201);
        }
    }
}
