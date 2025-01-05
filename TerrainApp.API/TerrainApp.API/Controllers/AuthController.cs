using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerrainApp.API.BusinessLogic.Auth.Login;
using TerrainApp.API.BusinessLogic.Auth.Refresh;
using TerrainApp.API.BusinessLogic.Users.Register;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Controllers
{
    public class AuthController : Controller
    {
        IMediator mediator;

        public AuthController(IDataBase dataBase, IMediator mediator)
        {
            this.mediator = mediator;
          

        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            LoginResponse response = await this.mediator.Send(loginRequest);
            return this.Ok(response);
            


        }
        [HttpPost("Refresh")]
        public async Task<ActionResult> Refresh(RefreshRequest refreshRequest)
        {
            RefreshResponse response = await this.mediator.Send(refreshRequest);
            return this.Ok(response);



        }

    }

}
