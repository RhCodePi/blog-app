using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Login;
using BlogApp.Application.DTOs.Login.Response;
using BlogApp.Application.DTOs.Token.Response;
using BlogApp.Application.Exceptions;
using BlogApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Persistance.Concretes.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthService(UserManager<AppUser> manager, SignInManager<AppUser> signInManager, ITokenService tokenService, IUserService userService)
        {
            _manager = manager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userService = userService;
        }

        public async Task<LoginResponse> Login(LoginDto model)
        {
            var user = await _manager.FindByNameAsync(model.UsernameOrEmail) ?? await _manager.FindByEmailAsync(model.UsernameOrEmail);

            if(user == null)
            {
                throw new UserNotFoundException("username or password wrong");
            }

            var result  = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);


            if (result.Succeeded)
            {
                var tokenRepsonse = _tokenService.CreateAccessToken(15, user);
                await _userService.UpdateRefreshTokenAsync(tokenRepsonse.RefreshToken, user, tokenRepsonse.Expiration, 15);
                return new()
                {
                    IsSuccess = true,
                    Message = "sign in succesfuly",
                    Token = tokenRepsonse
                };
            }
            throw new AuthenticationErrorException();
        }

        public async Task<TokenResponse> LoginWithRefreshToken(string refereshToken)
        {
            AppUser? user = await _manager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refereshToken);
            if(user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var tokenRepsonse = _tokenService.CreateAccessToken(15, user);
                await _userService.UpdateRefreshTokenAsync(tokenRepsonse.RefreshToken, user, tokenRepsonse.Expiration, 15);
                return tokenRepsonse;
            }else 
                throw new UserNotFoundException();
        }
    }
}
