using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest
{
    public class CreateRegisterRequestValidator:AbstractValidator<CreateRegisterRequestRequest>
    {
        public CreateRegisterRequestValidator() {
            this.RuleFor(x => x.Email).NotEmpty();
            this.RuleFor(x => x.Username).NotEmpty();
            this.RuleFor(x => x.Password).NotEmpty();
            this.RuleFor(x => x.Location).NotEmpty();

        }
    }
}
