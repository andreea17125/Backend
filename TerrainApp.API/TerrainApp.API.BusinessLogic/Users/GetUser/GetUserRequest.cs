using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TerrainApp.API.BusinessLogic.Users.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
