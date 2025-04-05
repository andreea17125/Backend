using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest;

namespace TerrainApp.API.BusinessLogic.Terrain.Import
{

    public class ImportTerrainRequest : IRequest<ImportTerrainResponse>
    
    {
        public List<ImportedDataDto> Documents { get; set; }



    }
}
