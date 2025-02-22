using MediatR;
using TerrainApp.API.CommonDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetAvailableUserRoles
{
  public class GetAvailableUserRolesHandler : IRequestHandler<GetAvailableUserRolesRequest, GetAvailableUserRolesResponse>
  {
    public async Task<GetAvailableUserRolesResponse> Handle(GetAvailableUserRolesRequest request, CancellationToken cancellationToken)
    {
      List<UserRoleDto> AvailableRoles = new List<UserRoleDto>
      {
          new UserRoleDto
        {
          Name = "Admin",
          Value = Domain.CommonDomain.EnumUser.Admin,
        },
           new UserRoleDto
        {
          Name = "Regular",
          Value = Domain.CommonDomain.EnumUser.Regular,
        },
            new UserRoleDto
        {
          Name = "Guest",
          Value = Domain.CommonDomain.EnumUser.Guest,
        },
             new UserRoleDto
        {
          Name = "Premium",
          Value = Domain.CommonDomain.EnumUser.Premium,
        },
      };
      GetAvailableUserRolesResponse response = new GetAvailableUserRolesResponse();
      response.Message = "User roles returned successfully";
      response.StatusCode = System.Net.HttpStatusCode.OK;
      response.AvailableRoles = AvailableRoles;
      return response;
    }
  }
}
