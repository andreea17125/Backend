using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Auth.ResetPassword
{
    public class ResetPasswordResponse
    {
        public string Message { get; set; }
        public bool Sentemail { get; set; }
        public short Status { get; set; }
    }
}
