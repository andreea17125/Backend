using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.RequestRegister;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest
{
  public class ApproveUserRegistrationHandler : IRequestHandler<ApproveUserRegistrationRequest, ApproveUserRegistrationResponse>
  {
    private IMongoCollection<UserRegisterRequest> userRegistrationCollection;
    private IMongoCollection<User> userCollection;

    public ApproveUserRegistrationHandler(IDataBase dataBase)
    {
      this.userRegistrationCollection = dataBase.GetUserRegistrationCollection();
      this.userCollection = dataBase.GetUserCollection();
    }
    public async Task<ApproveUserRegistrationResponse> Handle(ApproveUserRegistrationRequest request, CancellationToken cancellationToken)
    {
      var filter = Builders<UserRegisterRequest>.Filter.Eq(x => x.Id, request.Id);
      var update = Builders<UserRegisterRequest>.Update.Set(c => c.Status, RegisterRequestStatus.Approved);
      await this.userRegistrationCollection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken);
      
      UserRegisterRequest userRegisterRequest = await this.userRegistrationCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
      User user = new User
      {
        IsActive = true,
        Email = userRegisterRequest.Email,
        Username = userRegisterRequest.Username,
        PasswordHash = userRegisterRequest.PasswordHash,
      };

      await this.userCollection.InsertOneAsync(user, cancellationToken);
      return new ApproveUserRegistrationResponse
      {
        Message = "Approved",
        StatusCode = System.Net.HttpStatusCode.OK,
      };
    }
  }
}
