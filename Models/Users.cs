﻿namespace StoreEcommerce.Models
{
    public class Users
    {    
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class UserRegisterResponse 
    { 
        public string Message { get; set; }    
    
    }


    public class LoginUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
