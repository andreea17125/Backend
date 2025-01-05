using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.Users.GetAllUsers
{
    public class GetAllUsersValidator : AbstractValidator<GetAllUsersRequest>
    {
        public GetAllUsersValidator()
        {
            
        }
    }
}
