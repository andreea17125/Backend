using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Domain.RequestRegister
{


  public class UserRegisterRequest
  {
    public string Email;
    public string PasswordHash;
    public string Username;
    public RegisterRequestStatus Status = RegisterRequestStatus.Pending;
    public Location Location;

    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }


    public UserRegisterRequest()
    {
      this.Id = ObjectId.GenerateNewId().ToString();
    }
  }
}
