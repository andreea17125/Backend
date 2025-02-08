using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponses>
    {
        IMongoCollection<User> _users;
        public RegisterUserHandler(IDataBase dataBase)
        {
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");

        }
        public async Task<RegisterUserResponses> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
           
            User userToInsert = new User();
            userToInsert.Email = request.Email;
            userToInsert.PasswordHash = request.Password;
            userToInsert.Username = request.Username;
            userToInsert.ConfirmPassword= request.ConfirmPassword;
            await this._users.InsertOneAsync(userToInsert);
            RegisterUserResponses response = new RegisterUserResponses();
            response.Message = "User created succesfully";
            response.StatusCode = System.Net.HttpStatusCode.Created;
            response.UserId = userToInsert.Id;
            return response;
        }
    }
}
