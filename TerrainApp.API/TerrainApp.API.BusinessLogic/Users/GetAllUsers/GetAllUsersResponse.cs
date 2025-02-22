using System.Net;
using TerrainApp.API.CommonDomain;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetAllUsers
{
  public class GetAllUsersResponse : ResponseDto
  {
        public List<User> Users { get; set; }  
    }
}
