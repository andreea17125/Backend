using FluentValidation;
using MongoDB.Bson;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.RejectUserRegisterRequest
{
  public class RejectUserRegistrationValidator : AbstractValidator<RejectUserRegistrationRequest>
  {
    public RejectUserRegistrationValidator()
    {
      RuleFor(request => request.Id)
          .Must(id => ObjectId.TryParse(id, out _))
          .WithMessage("Invalid ObjectId format.");
    }
  }
}
