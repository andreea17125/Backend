﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Auth.Refresh
{
   public class RefreshResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public short ExpiresIn { get; set; }

        public string Message { get; set; }

        public short Status { get; set; }
    }
}
