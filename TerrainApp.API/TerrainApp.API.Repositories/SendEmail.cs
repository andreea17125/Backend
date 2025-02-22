using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.Repositories
{
    public class SendEmail
    {
        private SmtpClient smtpClient;

        public SendEmail()
        {
      this.smtpClient = new SmtpClient("smtp.office365.com")
      {
        Port = 587,
        Credentials = new NetworkCredential("robifodor1234576@outlook.com", "atngfprlikcxiiay"),
        EnableSsl = true, // This enables TLS encryption
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false
      };

    }
    public bool Send(MailMessage mailMessage)
        {
            try
            {
                mailMessage.From = new MailAddress("robifodor1234576@outlook.com", "TerrainApp");
                mailMessage.BodyEncoding = Encoding.UTF8;

                this.smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


  
}
