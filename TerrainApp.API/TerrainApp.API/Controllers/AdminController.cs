using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.GetAllUserRegisterRequests;
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
            ApproveUserRegistrationRequest approveUserRegistrationRequest = new ApproveUserRegistrationRequest
            {
                Id = id
            };
            var response = await this.mediator.Send(approveUserRegistrationRequest, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("GetUserRegistrationRequest")]
        public async Task<ActionResult> GetUserRequest(CancellationToken cancellationToken)
        {
            GetAllUserRegisterRequestsRequest GetAllUserRegistrationRequest = new();

            var response = await this.mediator.Send(GetAllUserRegistrationRequest, cancellationToken);
            return this.Ok(response);
        }
        [HttpPut("RejectUserRegistrationRequest/{id}")]
        public async Task<ActionResult> RejectUserRequest(string id, CancellationToken cancellationToken)
        {
            ApproveUserRegistrationRequest approveUserRegistrationRequest = new ApproveUserRegistrationRequest
            {
                Id = id
            };
            var response = await this.mediator.Send(approveUserRegistrationRequest, cancellationToken);
            return this.Ok(response);
        }
    }

}
