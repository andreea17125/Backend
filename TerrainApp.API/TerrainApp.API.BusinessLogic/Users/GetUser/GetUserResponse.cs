using System.Net;
using TerrainApp.API.CommonDomain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetUser
{
  public class GetUserResponse : ResponseDto
    {
        public User User { get; set; }
    }
}
