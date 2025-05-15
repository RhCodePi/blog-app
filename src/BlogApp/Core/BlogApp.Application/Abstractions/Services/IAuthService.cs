using BlogApp.Application.DTOs.Login;
using BlogApp.Application.DTOs.Login.Response;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginDto model);
    }
}
