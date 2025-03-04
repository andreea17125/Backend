using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain;
using TerrainApp.API.Domain.Terrain;

namespace TerrainApp.API.BusinessLogic.Auth.CheckResetPasswordUniqueCode
{
  public class CheckResetPasswordUniqueCodeHandler : IRequestHandler<CheckResetPasswordUniqueCodeRequest, CheckResetPasswordUniqueCodeResponse>
  {
    private IDataBase dataBase;

    public CheckResetPasswordUniqueCodeHandler(IDataBase dataBase)
    {
      this.dataBase = dataBase;
    }
    public async Task<CheckResetPasswordUniqueCodeResponse> Handle(CheckResetPasswordUniqueCodeRequest request, CancellationToken cancellationToken)
    {
      var loginHistory = await this.dataBase.GetLoginHistoryCollection().Find(Builders<LoginHistory>.Filter.Eq(x => x.ResetPassword.UniqueCode, request.UniqueGeneratedCode)).FirstOrDefaultAsync(cancellationToken);
      if (loginHistory == null)
      {
        return new CheckResetPasswordUniqueCodeResponse
        {
          Message = "Invalid code",
          StatusCode = System.Net.HttpStatusCode.Unauthorized,
        };
      }

      DateTime current = DateTime.UtcNow;
      var difference =(loginHistory.ResetPassword.CreateDate.Date - current.Date).Days;
      if(difference>5)
      {
        return new CheckResetPasswordUniqueCodeResponse
        {
          Message = "Code expired",
          StatusCode = System.Net.HttpStatusCode.Unauthorized,
        };
      }

      return new CheckResetPasswordUniqueCodeResponse
      {
        Message = "Code approved",
        StatusCode = System.Net.HttpStatusCode.OK,
      };
    }
  }
}
