using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Users.GetUser
{
    public class GetUserValidator : AbstractValidator<GetUserRequest>
    {
        public GetUserValidator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
