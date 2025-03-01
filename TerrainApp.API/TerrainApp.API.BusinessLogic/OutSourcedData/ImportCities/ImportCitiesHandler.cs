using MediatR;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.CommonDomain;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCities
{
    public class ImportCitiesHandler : IRequestHandler<ImportCitiesRequest, ImportCitiesResponse>
    {
        private readonly IDataBase dataBase;

        public ImportCitiesHandler(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public async Task<ImportCitiesResponse> Handle(ImportCitiesRequest request, CancellationToken cancellationToken)
        {
            await this.dataBase.GetCitiesCollection().InsertManyAsync(request.Cities, cancellationToken: cancellationToken);
            return new ImportCitiesResponse
            {
                Message = "Success",
                StatusCode = HttpStatusCode.Created,
            };
        }
    }
}


