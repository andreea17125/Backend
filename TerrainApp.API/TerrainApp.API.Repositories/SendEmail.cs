using System.Net;
using System.Net.Mail;
using System.Text;

namespace TerrainApp.API.Repositories
{
  public class SendEmail
  {
    private SmtpClient smtpClient;

    public SendEmail()
    {
      this.smtpClient = new SmtpClient("smtp.gmail.com")
      {
        Port = 587,
        Credentials = new NetworkCredential("fodorrobert1234576@gmail.com", "itehhbwilphpvjkj"),
        EnableSsl = true, 
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false
      };
    }

    public bool Send(MailMessage mailMessage)
    {
      try
      {
        mailMessage.From = new MailAddress("fodorrobert1234576@gmail.com", "TerrainApp");
        mailMessage.BodyEncoding = Encoding.UTF8;

        this.smtpClient.Send(mailMessage);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error sending email: " + ex.Message);
        return false;
      }
    }
  }
}
