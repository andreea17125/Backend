using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Auth.Login
{

    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        public IDataBase dataBase = null;
        public LoginHandler(IDataBase database)
        {
            dataBase = database;

        }
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)

        {


            var Generator = new GenerateAccessTokens();
            

            var user = dataBase.GetUserCollection().Find(u => u.Email == request.Email && u.PasswordHash == request.Password).FirstOrDefault();

            if (user == null)
            {
                LoginResponse loginResponse = new LoginResponse();
                loginResponse.Message = "Email si parola incorecte";
                loginResponse.Status = 401;
                return loginResponse;

            }



            var refreshToken = Generator.GenerateRefreshToken();

            LoginHistory history = new LoginHistory();
            history.Refreshtoken = refreshToken;
            history.Email = request.Email;
            var document = await this.dataBase.GetLoginHistoryCollection().Find(Builders<LoginHistory>.Filter.Eq(x => x.Email, history.Email)).FirstOrDefaultAsync();
            if (document != null)
            {
                history.Id = document.Id;

            }

            await this.dataBase.GetLoginHistoryCollection()
            .ReplaceOneAsync(Builders<LoginHistory>.Filter.Eq(c => c.Email, history.Email), history, new ReplaceOptions { IsUpsert = true });

            string role = "Guest";
            if(user.Role == EnumUser.Admin)
            {
                role = "Admin";
            }

            else if(user.Role ==EnumUser.Regular){
                role = "Regular";
            }
          

            var Response = Generator.GenerateAccessToken(request.Email,role);
            LoginResponse response = new LoginResponse();
            response.AccessToken = Response;
            response.RefreshToken = refreshToken;
            response.ExpiresIn = 60;
            response.Status = 200;
            response.Message = "Login cu succes";
            return response;
        }


    }
}
