using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Users.Register;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        IMongoCollection<User> _users;

        public UpdateUserHandler(IDataBase dataBase)
        {
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, request.UserId);
            var update = Builders<User>.Update
                .Set(x => x.Email, request.Email)
                .Set(x => x.FirstName, request.FirstName)
                .Set(x => x.LastName, request.LastName)
                .Set(x => x.Password, request.Password);

            var result = await this._users.UpdateOneAsync(filter, update);

            return new UpdateUserResponse
            {
                Message = result.ModifiedCount > 0 ? "User updated successfully" : "User not found",
                StatusCode = result.ModifiedCount > 0 ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound
            };
        }
    }
}
    

