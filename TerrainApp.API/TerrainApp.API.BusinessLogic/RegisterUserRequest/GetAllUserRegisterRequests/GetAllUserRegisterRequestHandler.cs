using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.RequestRegister;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.GetAllUserRegisterRequests
{
    public class GetAllUserRegisterRequestHandler : IRequestHandler<GetAllUserRegisterRequestsRequest, GetAllUserRegisterRequestResponse>
    {
        private readonly IMongoCollection<UserRegisterRequest> registerrequest;

        public GetAllUserRegisterRequestHandler(IDataBase dataBase)
        {
            registerrequest=dataBase.GetUserRegistrationCollection();
        }
        public async Task<GetAllUserRegisterRequestResponse> Handle(GetAllUserRegisterRequestsRequest request, CancellationToken cancellationToken)
        {
          List<UserRegisterRequest> pendings = await this.registerrequest.Find(Builders<UserRegisterRequest>.Filter.Eq(x => x.Status,RegisterRequestStatus.Pending)).ToListAsync(cancellationToken);
            List<UserRegisterRequest> approved = await this.registerrequest.Find(Builders<UserRegisterRequest>.Filter.Eq(x => x.Status, RegisterRequestStatus.Approved)).ToListAsync(cancellationToken);
            List<UserRegisterRequest> rejected = await this.registerrequest.Find(Builders<UserRegisterRequest>.Filter.Eq(x => x.Status, RegisterRequestStatus.Rejected)).ToListAsync(cancellationToken);
            GetAllUserRegisterRequestResponse response = new GetAllUserRegisterRequestResponse();
            response.Pendings = pendings;
            response.Approved = approved;
            response.Rejected = rejected;
            response.Message = "Succes";
            response.StatusCode  = System.Net.HttpStatusCode.OK;
            return response;
        }
    }
}
