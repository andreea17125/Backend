using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.Domain.UserDomain
{
    public class Security
    {
        public string RecoveryEmail { get; set; }
        public string RecoveryKey { get; set; }
        public string RecoveryPhoneNumber { get; set; }

        public bool IsRecoveryEmailValid()
        {
            return RecoveryEmail.Contains("@");
        }

    }
}
