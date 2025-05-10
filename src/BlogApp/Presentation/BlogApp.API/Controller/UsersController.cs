using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            var result = await _userService.CreateAppUser(userDTO);


            return Ok(result);
        }
    }
}
