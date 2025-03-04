namespace TerrainApp.API.Domain
{
  public class ResetPassword
  {
    public string UniqueCode { get; set; } = string.Empty;

    public DateTime CreateDate {  get; set; }
  }
}
