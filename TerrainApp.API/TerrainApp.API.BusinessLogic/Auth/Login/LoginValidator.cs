using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Auth.Login
{
   public class LoginValidator:AbstractValidator<LoginRequest>
    {
          public LoginValidator() { 
        this.RuleFor(x => x.Email).NotEmpty();
        this.RuleFor(x => x.Password).NotEmpty();


        }
}
}
