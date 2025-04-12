using MediatR;
using TerrainApp.API.DataAbstraction.IDataBase;

namespace TerrainApp.API.BusinessLogic.Terrain.Import
{
  public class ImportTerrainHandler : IRequestHandler<ImportTerrainRequest, ImportTerrainResponse>
  {
    private readonly IDataBase dataBase;

    public ImportTerrainHandler(IDataBase dataBase)
    {
      this.dataBase = dataBase;
    }
    public async Task<ImportTerrainResponse> Handle(ImportTerrainRequest request, CancellationToken cancellationToken)
    {
      return new ImportTerrainResponse { };

        }

  }
}
