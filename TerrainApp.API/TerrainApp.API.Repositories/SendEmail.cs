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
            this.smtpClient = new SmtpClient("smtp-mail.outlook.com");
            this.smtpClient.Port = 587;
            this.smtpClient.Credentials = new NetworkCredential("testanapp@outlook.com","andaosfg123");
            this.smtpClient.EnableSsl = true;
        }
        public bool Send(MailMessage mailMessage)
        {
            try
            {
                mailMessage.From = new MailAddress("testanapp@outlook.com", "TerrainApp");
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
