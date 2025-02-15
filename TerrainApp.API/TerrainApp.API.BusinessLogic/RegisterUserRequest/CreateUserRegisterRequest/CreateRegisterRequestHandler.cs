using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.RequestRegister;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest
{
  public class CreateRegisterRequestHandler : IRequestHandler<CreateRegisterRequestRequest, CreateRegisterRequestResponse>
  {
    IMongoCollection<UserRegisterRequest> registrationRequests;

    public CreateRegisterRequestHandler(IDataBase dataBase)
    {
      this.registrationRequests = dataBase.GetUserRegistrationCollection();
    }
    public async Task<CreateRegisterRequestResponse> Handle(CreateRegisterRequestRequest request, CancellationToken cancellationToken)
    {
      UserRegisterRequest registerRequest = new UserRegisterRequest
      {
        Email = request.Email,
        Location = request.Location,
        PasswordHash = request.Password,
        Username = request.Username,
        Status = RegisterRequestStatus.Pending
      };
      await this.registrationRequests.InsertOneAsync(registerRequest, cancellationToken);
      return new CreateRegisterRequestResponse
      {
        Message = "Request created successfully",
        StatusCode = HttpStatusCode.Created,
      };
    }
  }
}
