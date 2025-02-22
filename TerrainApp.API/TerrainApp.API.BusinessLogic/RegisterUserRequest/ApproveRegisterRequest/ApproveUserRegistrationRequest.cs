using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest
{
  public class ApproveUserRegistrationRequest : IRequest<ApproveUserRegistrationResponse>
  {
    public string Id { get; set; }
  }
}
