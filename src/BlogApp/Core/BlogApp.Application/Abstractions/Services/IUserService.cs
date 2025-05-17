using BlogApp.Application.DTOs.User;
using BlogApp.Application.DTOs.User.Response;
using BlogApp.Domain.Entities.Identity;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAppUser(CreateUserDTO userDTO);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
