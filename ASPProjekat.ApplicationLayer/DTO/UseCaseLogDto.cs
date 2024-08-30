using ASPProjekat.ApplicationLayer.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class UseCaseLogDto
    {
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
        public object UseCaseData { get; set; }
        public UseCaseLogDto(int useCase, int user, object useCaseData)
        {
            UseCaseId = useCase;
            UserId = user;
            UseCaseData= useCaseData;
        }
    }
}
