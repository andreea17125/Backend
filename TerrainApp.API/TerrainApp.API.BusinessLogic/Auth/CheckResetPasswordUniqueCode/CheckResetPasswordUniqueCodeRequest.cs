using MediatR;

namespace TerrainApp.API.BusinessLogic.Auth.CheckResetPasswordUniqueCode
{
  public class CheckResetPasswordUniqueCodeRequest : IRequest<CheckResetPasswordUniqueCodeResponse>
  {
    public string UniqueGeneratedCode { get; set; } = string.Empty;
  }
}
