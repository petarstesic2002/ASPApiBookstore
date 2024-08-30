using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProjekat.ApplicationLayer.DTO
{
    public class SendEmailDTO
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
