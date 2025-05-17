using BlogApp.Application.DTOs.Login;
using BlogApp.Application.DTOs.Login.Response;
using BlogApp.Application.DTOs.Token.Response;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginDto model);
        Task<TokenResponse> LoginWithRefreshToken(string refereshToken);
    }
}
