using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Net;
using System.Net.Mail;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Auth.Login;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.UserDomain;
using TerrainApp.API.Repositories;
using System.Xml.Linq;
using XSystem.Security.Cryptography;
using XAct.Messages;
using XAct.Users;

namespace TerrainApp.API.BusinessLogic.Auth.ResetPassword
{
  public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
  {
    public IDataBase dataBase = null;
    public ResetPasswordHandler(IDataBase database)
    {
      dataBase = database;

    }

    public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
      var userCollection = dataBase.GetUserCollection();
      var user = await userCollection.Find(Builders<Domain.UserDomain.User>.Filter.Eq(x => x.Email, request.Email)).FirstOrDefaultAsync();
      if (user == null)
      {
        ResetPasswordResponse reset = new ResetPasswordResponse();
        reset.Message = "Email not found";
        reset.Status = 401;

        return reset;
      }
      var finalEncryptedData = this.GenerateUniqueResetCode(user);
      await this.SendEmailAndStoreUniqueCode(finalEncryptedData, user);

      return new ResetPasswordResponse
      {
        Status = 200,
        Message = "Email sent"

      };
    }

    private async Task SendEmailAndStoreUniqueCode(string finalEncryptedData, Domain.UserDomain.User user)
    {
      TerrainApp.API.Domain.ResetPassword resetPassword = new()
      {
        CreateDate = DateTime.Now,
        UniqueCode = finalEncryptedData
      };
      var userLoginHistory = await this.dataBase.GetLoginHistoryCollection().UpdateOneAsync(Builders<LoginHistory>.Filter.Eq(x => x.Email, user.Email), Builders<LoginHistory>.Update.Set(x => x.ResetPassword, resetPassword));

      var sendemail = new SendEmail();
      string body = "Hello, " + user.FirstName + "\n here is you custom generated link for reseting the password. If it was not requested by you , ignore it. The link will expire in 5 days \n <a href=\"http://localhost:5173/resetPassword/" + finalEncryptedData + "/" + " > login </ a > ";
      MailMessage mail = new MailMessage
      {
        Subject = "Reset password request",
        Body = body,
        IsBodyHtml = true
      };
      mail.To.Add(user.Email);
      sendemail.Send(mail);
    }
    private string GenerateUniqueResetCode(Domain.UserDomain.User user)
    {
      string userEmail = user.Email;
      string userPassword = user.PasswordHash;
      string userId = user.Id;
      string currentDateTime = DateTime.Now.ToString();

      var byteArrayOfPersonalDocuments = ASCIIEncoding.ASCII.GetBytes(userEmail + userPassword + userId + currentDateTime);
      byte[] tmpNewHash;
      tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(byteArrayOfPersonalDocuments);
      var finalEncryptedData = ByteArrayToString(tmpNewHash);
      return finalEncryptedData;
    }
    private string ByteArrayToString(byte[] arrInput)
    {
      int i;
      StringBuilder sOutput = new StringBuilder(arrInput.Length);
      for (i = 0; i < arrInput.Length; i++)
      {
        sOutput.Append(arrInput[i].ToString("X2"));
      }
      return sOutput.ToString();
    }

  }
}
