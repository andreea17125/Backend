using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.Auth.Login;

namespace TerrainApp.API.BusinessLogic.Auth.Refresh
{
    public class RefreshRequest : IRequest<RefreshResponse>
    {
        public string RefreshToken { get; set; }
      
    }
}
