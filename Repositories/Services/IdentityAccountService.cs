using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class IdentityAccountService : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        // inject jwt service
        private JwtTokenService jwtTokenService;


        public IdentityAccountService(UserManager<ApplicationUser> userManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            this.jwtTokenService = jwtTokenService;
        }

        public async Task<RegisterDto> Register(RegisterDto registerdUserDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password); // Assuming Password is a property in RegisterDto

            if (result.Succeeded)
            {
                return new RegisterDto()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? "Password" :
                                error.Code.Contains("Email") ? "Email" :
                                error.Code.Contains("Username") ? "Username" : "";

                modelState.AddModelError(errorCode, error.Description);
            }

            return null;
        }


        // login
        public async Task<LoginDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return null; // User not found
            }

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new LoginDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(7))
                };
            }

            return null;
        }


    }

}

