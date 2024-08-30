using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPProjekat.ApplicationLayer.DTO;

namespace ASPProjekat.ApplicationLayer.Email
{
    public interface IEmailSender
    {
        void SendEmail(SendEmailDTO emailObj);
    }
}
