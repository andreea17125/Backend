using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest
{
  public class RejectUserRegistrationResponse
  {
    public string Message { get; set; }

    public HttpStatusCode StatusCode { get; set; }
  }
}
