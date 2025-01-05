using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.BusinessLogic.Users.Update
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            this.RuleFor(x => x.Password).NotEmpty();
            this.RuleFor(x => x.FirstName).NotEmpty();
            this.RuleFor(x => x.LastName).NotEmpty();

            this.RuleFor(x => x.Email).NotEmpty();
        }
    }
}
