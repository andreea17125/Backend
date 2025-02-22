using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.RequestRegister;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest
{
  public class RejectUserRegistrationHandler : IRequestHandler<RejectUserRegistrationRequest, RejectUserRegistrationResponse>
  {
    private IMongoCollection<UserRegisterRequest> userRegistrationCollection;
    public RejectUserRegistrationHandler(IDataBase dataBase)
    {
      this.userRegistrationCollection = dataBase.GetUserRegistrationCollection();
    }
    public async Task<RejectUserRegistrationResponse> Handle(RejectUserRegistrationRequest request, CancellationToken cancellationToken)
    {
      var filter = Builders<UserRegisterRequest>.Filter.Eq(x => x.Id, request.Id);
      var update = Builders<UserRegisterRequest>.Update.Set(c => c.Status, RegisterRequestStatus.Rejected);
      await this.userRegistrationCollection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken);
      return new RejectUserRegistrationResponse
      {
        Message = "Rejected",
        StatusCode = System.Net.HttpStatusCode.OK,
      };

    }
  }
}
