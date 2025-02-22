using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest
{
   public class CreateRegisterRequestRequest : IRequest<CreateRegisterRequestResponse>
    {
        public string Email {  get; set; }
        public string Password {  get; set; }
        public string Username {  get; set; }
        public Location Location {  get; set; }
    }
}
