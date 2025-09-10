using System.Net.Http.Headers;
using Microsoft.IdentityModel.JsonWebTokens;

namespace StoreEcommerce.DTO
{
    public class UserRegisterDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

}
