using BlogApp.Application.Abstractions.Services;
using BlogApp.Application.DTOs.Login;
using BlogApp.Application.DTOs.Login.Response;
using BlogApp.Application.Exceptions;
using BlogApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Persistance.Concretes.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _manager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthService(UserManager<AppUser> manager, SignInManager<AppUser> signInManager)
        {
            _manager = manager;
            _signInManager = signInManager;
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
                return new()
                {
                    IsSuccess = true,
                    Message = "sign in succesfuly"
                };
            }
            else
            {
                return new()
                {
                    IsSuccess =  false,
                    Message = "Cannot sign in. Check your username or password"
                };
            }
        }
    }
}
