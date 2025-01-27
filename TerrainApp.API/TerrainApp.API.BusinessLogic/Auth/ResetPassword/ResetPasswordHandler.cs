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
            var user = await userCollection.Find(Builders<User>.Filter.Eq(x => x.Email, request.Email)).FirstOrDefaultAsync();
            if (user == null)
            {
                ResetPasswordResponse reset = new ResetPasswordResponse();
                reset.Message = "Email not found";
                reset.Status = 401;

                return reset;
            }
            var sendemail = new SendEmail();
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("testanapp@outlook.com"),
                Subject = "Test Email",
                Body = "Hello.",
                IsBodyHtml = false

            };
            mail.To.Add(request.Email);
            sendemail.Send(mail);
            return new ResetPasswordResponse { 
            Status = 200,
            Message = "Email sent"
            
            };



        }
    }
}
