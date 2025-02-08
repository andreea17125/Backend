using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TerrainApp.API.BusinessLogic.Users.Register
{
    public class RegisterUserRequest: IRequest<RegisterUserResponses>
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public bool? Approved { get; set; } = null;

    }
}
