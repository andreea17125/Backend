using System.Net;

namespace TerrainApp.API.CommonDomain
{
  public class ResponseDto
  {
    public string Message { get; set; } = "Unknown Message";

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.ServiceUnavailable;
  }
}
