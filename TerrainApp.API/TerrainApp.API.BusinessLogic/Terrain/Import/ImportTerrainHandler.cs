using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest;

namespace TerrainApp.API.BusinessLogic.Terrain.Import
{
    public class ImportTerrainHandler : IRequestHandler<ImportTerrainRequest, ImportTerrainResponse>
    {
        public async Task<ImportTerrainResponse> Handle(ImportTerrainRequest request, CancellationToken cancellationToken)
        {
            List<ImportedDataDto>RawDataList = new List<ImportedDataDto>();
           

            return new ImportTerrainResponse();
        }

    }
}
