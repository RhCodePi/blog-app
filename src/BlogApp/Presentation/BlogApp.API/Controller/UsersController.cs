using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.User;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUserDTO> _registarValidator;

        public UsersController(IUserService userService, IValidator<CreateUserDTO> registarValidator)
        {
            _userService = userService;
            _registarValidator = registarValidator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDTO)
        {
            var validResult = _registarValidator.Validate(userDTO);

            if(!validResult.IsValid)
            {
                return BadRequest(validResult.Errors);
            }


            var result = await _userService.CreateAppUser(userDTO);


            return Ok(result);
        }
    }
}
