using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TerrainApp.API.BusinessLogic.Auth.ResetPassword
{
    public class ResetPasswordRequest:IRequest<ResetPasswordResponse>
    {
        public string Email { get; set; }
       
    }
}
