using FluentValidation;

namespace TerrainApp.API.BusinessLogic.OutSourcedData.ImportCountries
{
  public class ImportCountriesValidator : AbstractValidator<ImportCountriesRequest>
  {
    public ImportCountriesValidator()
    {
      this.RuleFor(request => request.Countries.Count).GreaterThan(0);
    }
  }
}
