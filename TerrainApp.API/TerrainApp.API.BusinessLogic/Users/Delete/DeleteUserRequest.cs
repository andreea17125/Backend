using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.BusinessLogic.Users.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public string UserId { get; set; } = string.Empty;

    }
}
