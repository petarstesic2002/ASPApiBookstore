using Microsoft.AspNetCore.Http;

namespace ASPProjekat.API.DTO
{
    public class FileUploadDto
    {
        public IFormFile File { get; set; }
    }
}
