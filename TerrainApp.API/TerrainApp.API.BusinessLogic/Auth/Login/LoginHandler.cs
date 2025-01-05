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
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Database.DataBase;
using TerrainApp.API.Domain;

namespace TerrainApp.API.BusinessLogic.Auth.Login
{

    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        public IDataBase dataBase = null;
        public LoginHandler(IDataBase database) { 
           dataBase = database;
           
        }
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            //cauta mi user ul in db dupa email verificam daca datele sunt valide

            var user = dataBase.GetUserCollection().Find(u => u.Email == request.Email && u.Password == request.Password).FirstOrDefault();

            if (user == null)
            {
               LoginResponse loginResponse = new LoginResponse();
                loginResponse.Message = "Email si parola incorecte";
                loginResponse.Status = 401;
                return loginResponse;

            }

           

            var refreshToken = GenerateRefreshToken();
            
            LoginHistory history = new LoginHistory();
            history.Refreshtoken = refreshToken;
            history.Email= request.Email;
            var document = await this.dataBase.GetLoginHistoryCollection().Find(Builders<LoginHistory>.Filter.Eq(x=>x.Email,history.Email)).FirstOrDefaultAsync();
            if (document != null)
            {
                history.Id= document.Id;
                   
            }

            await this.dataBase.GetLoginHistoryCollection()
            .ReplaceOneAsync(Builders<LoginHistory>.Filter.Eq(c => c.Email, history.Email), history, new ReplaceOptions { IsUpsert = true });


            var Response = GenerateAccessToken(request.Email);
            LoginResponse response = new LoginResponse();
            response.AccessToken = new JwtSecurityTokenHandler().WriteToken(Response);
            response.RefreshToken = refreshToken;
            response.ExpiresIn = 60;
           response.Status = 200;
            response.Message = "Login cu succes";
            return response;
        }
    
    private JwtSecurityToken GenerateAccessToken(string Email)
        {
            var claims = new List<Claim>
                                         { 
                           new Claim(ClaimTypes.Name, Email)
                                         };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1), // Token expiration time
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("averylongsecretkeythatisrequiredtobeused")),
                    SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber); // Secure random refresh token
            }
        }
    }
}
