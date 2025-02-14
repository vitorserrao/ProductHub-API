using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductHub_API.Dto.Users;
using ProductHub_API.Models;
using ProductHub_API.Services.Interfaces;

namespace ProductHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<UsersModel>>> CreateUser([FromBody] UsersDto usersDto)
        {
            var newUser = await _usersService.CreateUser(usersDto);
            return Ok(newUser);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel<string>>> Login([FromBody] UsersDto usersDto)
        {
            var login = await _usersService.Login(usersDto);
           
            return Ok(new {  message = login.Message, token = login.Data } );
        }


    }
}
