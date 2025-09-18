using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreEcommerce.Data;
using StoreEcommerce.DTO;
using StoreEcommerce.Interfaces;
using StoreEcommerce.Models;

namespace StoreEcommerce.Services
{
    public class UserService : IUserInterface
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<UserService> _logger;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper , ApplicationDbContext dbContext , ILogger<UserService> logger, IConfiguration configuration) 
        { 
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<UserRegisterResponse> AddUserRegisteration(UserRegisterDTO userRegisterDTO)
        {
            UserRegisterResponse registerResponse = new UserRegisterResponse();
            try
            {
                _logger.LogInformation("A new user to register: {Email}" , userRegisterDTO.Email);

                //Password needs to be hashed before saving it to the database
                _logger.LogInformation("Password Hash");
                string userPassword = PasswordHashing(userRegisterDTO.PasswordHash);

                //The entry is now added to the database
                var userRegisterInfo = _mapper.Map<Users>(userRegisterDTO);
                userRegisterInfo.PasswordHash = userPassword;
                userRegisterInfo.CreatedAt = DateTime.Now;
                await _dbContext.Users.AddAsync(userRegisterInfo);
                await _dbContext.SaveChangesAsync();
                registerResponse.Message = "Successfully Registered";
                return registerResponse;
            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);
                registerResponse.Message = "Registeration Failed";
                return registerResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);
                registerResponse.Message = "Registeration Failed";
                return registerResponse;
            }
        }

        public async Task<LoginResponseDTO> LoginUser(LoginUserRequest requestLogin)
        {
            LoginResponseDTO responseLogin = new LoginResponseDTO();
            try
            {
                _logger.LogInformation("User logged in {Email}" , requestLogin.Email);

                _logger.LogInformation("Password Hash");
                string userPassword = PasswordHashing(requestLogin.PasswordHash);
                var userInformation = await _dbContext.Users.FirstOrDefaultAsync(e => e.Email == requestLogin.Email && e.PasswordHash == userPassword);
                if (userInformation is not null)
                {
                    _logger.LogInformation("Generating Token");

                    var token = GenerateJwtToken(requestLogin.Email);

                    responseLogin = new LoginResponseDTO()
                    {
                        Token = token,
                        Status = "AUTHORIZED"
                    };
                    return responseLogin;

                }
                return responseLogin;


            }
            catch (DbException dbException)
            {
                _logger.LogError("Database exception incurred: {DBEx}", dbException);

                responseLogin = new LoginResponseDTO()
                {
                    Token = string.Empty,
                    Status = "Invalid User"
                };
                return responseLogin;


            }
            catch (Exception ex)
            {
                _logger.LogError("Database exception incurred: {Ex}", ex);

                responseLogin = new LoginResponseDTO()
                {
                    Token = string.Empty,
                    Status = "Invalid User"
                };

                return responseLogin;

            }
        }


        public string GenerateJwtToken(string email)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , email),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };


            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"]!)),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string PasswordHashing(string password)
        {
            string hashedPassword = string.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                hashedPassword = Convert.ToBase64String(hash);
            }
            return hashedPassword;
        }
    }
}
