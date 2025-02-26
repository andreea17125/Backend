using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCities
{
    public class ImportCitiesValidator : AbstractValidator<ImportCitiesRequest>
    {
        public ImportCitiesValidator()
        {
            this.RuleFor(request => request.Cities.Count).GreaterThan(0).WithMessage("You must provide at least one city.");
            this.RuleForEach(request => request.Cities).ChildRules(city =>
            {
                city.RuleFor(c => c.Name).NotEmpty().WithMessage("City name cannot be empty.");
                city.RuleFor(c => c.Country).NotEmpty().WithMessage("Country cannot be empty.");
            });
        }
    }
}
