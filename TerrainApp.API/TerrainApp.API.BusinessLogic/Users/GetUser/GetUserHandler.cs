using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;
using TerrainApp.API.Repositories;

namespace TerrainApp.API.BusinessLogic.Users.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {


        IMongoCollection<User> _users;

        public GetUserHandler(IDataBase dataBase)
        {
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
         var user =  await this._users.Find(Builders<User>.Filter.Eq(x => x.Id, request.UserId)).FirstOrDefaultAsync();
            

            return new GetUserResponse
            {
                User = user,
                Message = user != null ? "User retrieved successfully" : "User not found",
                StatusCode = user != null ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound
            };
        }
    }
}
