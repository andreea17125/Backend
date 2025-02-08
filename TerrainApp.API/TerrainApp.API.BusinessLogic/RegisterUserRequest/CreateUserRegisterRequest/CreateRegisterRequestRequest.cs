using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest
{
   public class CreateRegisterRequestRequest
    {
        public string Email;
        public string Password;
        public string Username;
        public Location Location;
    }
}
