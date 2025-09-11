using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using StoreEcommerce.Data;
using StoreEcommerce.DTO;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;

namespace StoreEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        private readonly ILogger<IUserInterface> _logger;

        public UserController(ILogger<IUserInterface> logger, IUserInterface userInterface)
        {
            _logger = logger;
            _userInterface = userInterface;
        }


        [HttpPost("register")]
        public async Task<ActionResult> AddNewUser(UserRegisterDTO userRegisterRequest)
        {
            try
            {
                _logger.LogInformation("User Registeration Request Landed on User Controller");
                var message = await _userInterface.AddUserRegisteration(userRegisterRequest);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> UserLogin(LoginUserRequest userRequestLogin)
        {
            try
            {
                _logger.LogInformation("User Login Request Landed on User Controller");
                LoginResponseDTO loginResponse = new LoginResponseDTO();
                loginResponse = await _userInterface.LoginUser(userRequestLogin);
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception incurred: {Ex}", ex);
                return NotFound();
            }
        }
    }
}
