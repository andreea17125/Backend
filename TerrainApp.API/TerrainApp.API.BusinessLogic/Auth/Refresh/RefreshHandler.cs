using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Auth.Login;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Auth.Refresh
{
    public class RefreshHandler : IRequestHandler<RefreshRequest, RefreshResponse>
    {
        public IDataBase dataBase = null;
        public RefreshHandler(IDataBase database)
        {
            dataBase = database;

        }
        private static Dictionary<string, string> RefreshTokens = new Dictionary<string, string>();

        public async Task<RefreshResponse> Handle(RefreshRequest request, CancellationToken cancellationToken)
        {

            var GeneratorR = new GenerateAccessTokens();
            var LoginHistory = await this.dataBase.GetLoginHistoryCollection().Find(Builders<LoginHistory>.Filter.Eq(x => x.Refreshtoken, request.RefreshToken)).FirstOrDefaultAsync();
            var user = dataBase.GetUserCollection().Find(u => u.Email == LoginHistory.Email).FirstOrDefault();

            if (user == null)
            {
                RefreshResponse RefreshResponse = new RefreshResponse();
                RefreshResponse.Message = "Email si parola incorecte";
                RefreshResponse.Status = 401;
                return RefreshResponse;
            }
            string role = "Guest";
            if (user.Role == EnumUser.Admin)
            {
                role = "Admin";
            }

            else if (user.Role == EnumUser.Regular)
            {
                role = "Regular";
            }
            var email = LoginHistory.Email;
            var newAccessToken =GeneratorR.GenerateAccessToken(email,role);
            var newRefreshToken = GeneratorR.GenerateRefreshToken();
            var document = await this.dataBase.GetLoginHistoryCollection().Find(Builders<LoginHistory>.Filter.Eq(x => x.Email, email)).FirstOrDefaultAsync();
            if (document != null)
            {
                document.Refreshtoken = newRefreshToken;

            }

            await this.dataBase.GetLoginHistoryCollection()
            .ReplaceOneAsync(Builders<LoginHistory>.Filter.Eq(c => c.Email, email), document, new ReplaceOptions { IsUpsert = true });


            RefreshResponse refreshResponse = new RefreshResponse();
            refreshResponse.RefreshToken = newRefreshToken;
            refreshResponse.AccessToken = newAccessToken;
            refreshResponse.ExpiresIn = 300;
            refreshResponse.Status = 200;
            refreshResponse.Message = "Login cu succes";
            return refreshResponse;


        }
       
    }
}

