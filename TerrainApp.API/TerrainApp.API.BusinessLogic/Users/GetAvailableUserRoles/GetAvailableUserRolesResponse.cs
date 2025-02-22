using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetAvailableUserRoles
{
  public class GetAvailableUserRolesResponse : ResponseDto
  {
    public List<UserRoleDto> AvailableRoles {  get; set; } = new List<UserRoleDto>();
  }
}
