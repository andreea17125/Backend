using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TerrainApp.API.BusinessLogic.Users.Register;

namespace TerrainApp.API.BusinessLogic.Users.Delete
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            this.RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
