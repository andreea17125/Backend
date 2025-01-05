﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TerrainApp.API.BusinessLogic.Users.Delete
{
    public class DeleteUserResponse
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string UserId { get; set; }

    }
}