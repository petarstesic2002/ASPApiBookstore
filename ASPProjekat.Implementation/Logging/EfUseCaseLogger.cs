using ASPProjekat.ApplicationLayer.DTO;
using ASPProjekat.ApplicationLayer.UseCase;
using ASPProjekat.DataAccess;
using ASPProjekat.DomainLayer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly ASPContext _context;

        public EfUseCaseLogger(ASPContext context)
        {
            _context = context;
        }
        public void Log(UseCaseLogDto logObj)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                UseCaseData = JsonConvert.SerializeObject(logObj.UseCaseData),
                UseCaseId = logObj.UseCaseId,
                UserId = logObj.UserId!=0? logObj.UserId:null
            });
            _context.SaveChanges();
        }
    }
}
