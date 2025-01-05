using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TerrainApp.API.BusinessLogic.Users.Update
{
    public class UpdateUserRequest:IRequest<UpdateUserResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string UserId { get; set; }
    }
}
