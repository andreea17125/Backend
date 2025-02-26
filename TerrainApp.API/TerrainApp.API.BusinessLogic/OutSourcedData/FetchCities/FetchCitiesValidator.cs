using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.FetchCities
{
    public class FetchCitiesValidator : AbstractValidator<FetchCitiesRequest>
    {
        public FetchCitiesValidator()
        {
            RuleFor(request => request.Country)
                .NotEmpty().WithMessage("Country must be provided.");
        }
    }
}
