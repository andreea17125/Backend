using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Auth.CheckResetPasswordUniqueCode
{
  public class CheckResetPasswordUniqueCodeValidator : AbstractValidator<CheckResetPasswordUniqueCodeRequest>
  {
    public CheckResetPasswordUniqueCodeValidator()
    {
      this.RuleFor(request => request.UniqueGeneratedCode).NotEmpty();
    }
  }
}
