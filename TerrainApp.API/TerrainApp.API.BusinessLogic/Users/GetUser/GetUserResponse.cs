using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.BusinessLogic.Users.GetUser
{
    public class GetUserResponse 
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public User User { get; set; }
    }
}
