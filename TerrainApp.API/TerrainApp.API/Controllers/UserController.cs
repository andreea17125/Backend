using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCities;
using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries;
using TerrainApp.API.BusinessLogic.OutSourcedData.ImportCities;

using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries;

using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries;

using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries;

using TerrainApp.API.BusinessLogic.OutSourcedData.FetchCountries;

using TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest;
using TerrainApp.API.BusinessLogic.Users.Delete;
using TerrainApp.API.BusinessLogic.Users.GetAllUsers;
using TerrainApp.API.BusinessLogic.Users.GetAvailableUserRoles;
using TerrainApp.API.BusinessLogic.Users.GetUser;
using TerrainApp.API.BusinessLogic.Users.Register;
using TerrainApp.API.BusinessLogic.Users.Update;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;
using Microsoft.AspNetCore.Authorization;

namespace TerrainApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
    //[AuthorizeToken]

    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("RequestRegister")]
        public async Task<ActionResult> RequestRegister(CreateRegisterRequestRequest request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("FetchCountries")]
        public async Task<ActionResult> FetchCountries(CancellationToken cancellationToken)
        {
            FetchCountriesRequest request = new();
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("FetchCities/{country}")]
        public async Task<ActionResult> FetchCities(string country, CancellationToken cancellationToken)
        {
            FetchCitiesRequest request = new() { Country = country };
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet("GetAvailableRoles")]
        [AllowAnonymous]
        public async Task<ActionResult> GetUserRoles(CancellationToken cancellationToken)
        {
            GetAvailableUserRolesRequest request = new();
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }
    }

}
