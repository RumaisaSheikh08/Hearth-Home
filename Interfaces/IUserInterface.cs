using Microsoft.AspNetCore.Identity.Data;
using StoreEcommerce.DTO;
using StoreEcommerce.Models;

namespace StoreEcommerce.Interfaces
{
    public interface IUserInterface
    {
        Task<string> AddUserRegisteration(UserRegisterDTO userRegisterDTO);
        Task<LoginResponseDTO> LoginUser(LoginUserRequest requestLogin);
    }
}
