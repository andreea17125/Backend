using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IMongoCollection<User> _users;

        public DeleteUserHandler(IDataBase dataBase)
        {
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, request.UserId);
            var result = await this._users.DeleteOneAsync(filter);

            var response = new DeleteUserResponse
            {
                Message = result.DeletedCount > 0 ? "User deleted successfully" : "User not found",
                StatusCode = result.DeletedCount > 0 ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound
            };

            return response;
        }
    }
}

