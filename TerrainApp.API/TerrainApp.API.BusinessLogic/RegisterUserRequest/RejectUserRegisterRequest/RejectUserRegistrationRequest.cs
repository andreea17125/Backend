using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest
{
  public class RejectUserRegistrationRequest : IRequest<RejectUserRegistrationResponse>
  {
    public string Id { get; set; }
  }
}
