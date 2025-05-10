using BlogApp.Application.DTOs.User;
using BlogApp.Application.DTOs.User.Response;

namespace BlogApp.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAppUser(CreateUserDTO userDTO);
    }
}
