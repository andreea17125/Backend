using FluentValidation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.ApproveRegisterRequest
{
  public class ApproveUserRegistrationValidator : AbstractValidator<ApproveUserRegistrationRequest>
  {
    public ApproveUserRegistrationValidator()
    {
      RuleFor(request => request.Id)
                      .Must(id => ObjectId.TryParse(id, out _))
                      .WithMessage("Invalid ObjectId format.");
    }
  }
}
