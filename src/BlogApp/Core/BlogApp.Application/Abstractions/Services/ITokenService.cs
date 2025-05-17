using BlogApp.Application.DTOs.Token.Response;
using BlogApp.Domain.Entities.Identity;

namespace BlogApp.Application.Abstractions.Services
{
    public interface ITokenService
    {
        TokenResponse CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
