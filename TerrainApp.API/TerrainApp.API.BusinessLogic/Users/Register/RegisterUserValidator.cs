using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Users.Register
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator() {
            this.RuleFor(x => x.Password).NotEmpty();

            this.RuleFor(x => x.Email).NotEmpty();
        } 
    }
}
