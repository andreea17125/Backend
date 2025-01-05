using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Auth.Refresh
{
    public class RefreshValidator:AbstractValidator<RefreshRequest>
    {
        public RefreshValidator()
        {
            this.RuleFor(x => x.RefreshToken).NotEmpty();

            
        }
    }
}
