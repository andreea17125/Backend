using MediatR;
using Microsoft.AspNetCore.Mvc;

using TerrainApp.API.BusinessLogic.OutSourcedData.ImportCities;

using TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.GetAllUserRegisterRequests;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest;
using TerrainApp.API.BusinessLogic.Users.Delete;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    //[AuthorizeAdmin]
 
    public class AdminController : ControllerBase
    {
        private readonly IMediator mediator;

        public AdminController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPut("ApproveUserRegistrationRequest/{id}")]
        public async Task<ActionResult> ApproveUserRequest(string id, CancellationToken cancellationToken)
        {
            var request = new ApproveUserRegistrationRequest { Id = id };
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpPut("RejectUserRegistrationRequest/{id}")]
        public async Task<ActionResult> RejectUserRequest(string id, CancellationToken cancellationToken)
        {
            var request = new RejectUserRegistrationRequest { Id = id };
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("GetUserRegistrationRequests")]
        public async Task<ActionResult> GetUserRequests(CancellationToken cancellationToken)
        {
            var request = new GetAllUserRegisterRequestsRequest();
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpPost("ImportCountries")]
        public async Task<ActionResult> ImportCountries(ImportCountriesRequest request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpPost("ImportCities")]
        public async Task<ActionResult> ImportCities(ImportCitiesRequest request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var deleteUserRequest = new DeleteUserRequest { UserId = id };
            DeleteUserResponse response = await this.mediator.Send(deleteUserRequest);
            return this.Ok(response);
        }
    }


}
