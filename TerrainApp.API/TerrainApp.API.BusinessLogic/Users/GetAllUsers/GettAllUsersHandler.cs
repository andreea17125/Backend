using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        IMongoCollection<User> _users;

        public GetAllUsersHandler(IDataBase dataBase)
        {
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await this._users.Find(Builders<User>.Filter.Empty).ToListAsync();

            return new GetAllUsersResponse
            {
                Users = users,
                Message = users.Any() ? "Users retrieved successfully" : "No users found",
                StatusCode = users.Any() ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound
            };
        }
    }
    }
