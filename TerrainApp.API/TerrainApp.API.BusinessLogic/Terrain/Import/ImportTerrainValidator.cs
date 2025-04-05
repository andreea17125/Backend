using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TerrainApp.API.BusinessLogic.RegisterUserRequest.CreateUserRegisterRequest;

namespace TerrainApp.API.BusinessLogic.Terrain.Import
{
    public class ImportTerrainValidator : AbstractValidator<ImportTerrainRequest>
    {
        public ImportTerrainValidator()
        {
            this.RuleFor(x => x.Documents).NotEmpty();
        }

    }
}
