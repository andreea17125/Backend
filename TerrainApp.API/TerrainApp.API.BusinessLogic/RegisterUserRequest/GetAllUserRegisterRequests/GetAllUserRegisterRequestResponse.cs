using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.Domain.RequestRegister;

namespace TerrainApp.API.BusinessLogic.RegisterUserRequest.GetAllUserRegisterRequests
{
    public class GetAllUserRegisterRequestResponse
    {
        public List<UserRegisterRequest> Pendings { get; set; }
        public List<UserRegisterRequest> Approved { get; set; }
        public List<UserRegisterRequest> Rejected { get; set; }
        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }

    }
}
