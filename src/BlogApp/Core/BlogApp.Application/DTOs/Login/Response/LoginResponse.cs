
using Dtos = BlogApp.Application.DTOs.Token.Response;

namespace BlogApp.Application.DTOs.Login.Response
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Dtos.TokenResponse? Token { get; set; }
    }
}
