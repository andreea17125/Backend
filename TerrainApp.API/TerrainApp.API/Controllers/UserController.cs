﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TerrainApp.API.BusinessLogic.Users.Delete;
using TerrainApp.API.BusinessLogic.Users.GetAllUsers;
using TerrainApp.API.BusinessLogic.Users.GetUser;
using TerrainApp.API.BusinessLogic.Users.Register;
using TerrainApp.API.BusinessLogic.Users.Update;
using TerrainApp.API.DataAbstraction.IDataBase;
using TerrainApp.API.Domain.UserDomain;

namespace TerrainApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class UserController : ControllerBase
    {
        IMongoCollection<User> _users;
        IMediator mediator;

        public UserController(IDataBase dataBase, IMediator mediator)
        {
            this.mediator = mediator;
            this._users = dataBase.GetMongoDatabase().GetCollection<User>("Users");
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(RegisterUserRequest user)
        {
            RegisterUserResponses response = await this.mediator.Send(user);
            return this.Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UpdateUserRequest user)
        {
            UpdateUserResponse response = await this.mediator.Send(user);
            return this.Ok(response);
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var deleteUserRequest = new DeleteUserRequest { UserId = id };
            DeleteUserResponse response = await this.mediator.Send(deleteUserRequest);
            return this.Ok(response);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            var getUserRequest = new GetUserRequest { UserId = id };
            GetUserResponse response = await this.mediator.Send(getUserRequest);
            return this.Ok(response);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var getAllUsersRequest = new GetAllUsersRequest();
            GetAllUsersResponse response = await this.mediator.Send(getAllUsersRequest);
            return this.Ok(response);
        }
    }
}
