using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Login;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _authService.Login(model);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginWithRefreshToken(LoginWtihRefreshTokenDTO model)
        {
            var result = await _authService.LoginWithRefreshToken(model.RefreshToken);

            return Ok(result);
        }
    }
}
