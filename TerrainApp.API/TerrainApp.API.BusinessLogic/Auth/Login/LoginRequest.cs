using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.BusinessLogic.Auth.Login
{
    public class LoginRequest: IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
