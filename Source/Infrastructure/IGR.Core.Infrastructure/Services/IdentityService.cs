using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using IGR.Core.Application.Services;
using IGR.Core.Application.Services.Response;
using IGR.Core.Constant.Constant;
using IGR.Core.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IGR.Core.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        #region Fields

        private readonly SignInManager<AppUserIdentity> _signInManager;
        private readonly UserManager<AppUserIdentity> _userManager;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public IdentityService(
            UserManager<AppUserIdentity> userManager, 
            SignInManager<AppUserIdentity> signInManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        #endregion

        #region IIdentityService Members

        public async Task<IdentityResponse> CreateAsync(int accountId, string email, string password)
        {
            var response = new IdentityResponse();
            try
            {
                var user = new AppUserIdentity
                {
                    AccountId = accountId,
                    UserName = email,
                    Email = email
                };

                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    response.AddErrorMessages(result.Errors.Select(item => item.Description));

                    return response;
                }

                response.UserId = user.Id;
            }
            catch (Exception e)
            {
                response.AddErrorMessage(e.Message);
            }

            return response;
        }

        public async Task<IdentityResponse> LoginAsync(
            string email, 
            string password)
        {
            var response = new IdentityResponse();
            var loginResult = await _signInManager.PasswordSignInAsync(email, password, false, false);
            
            if (!loginResult.Succeeded)
            {
                response.ErrorMessages.Add("Invalid email or password");
                return response;
            }

            var user = await _userManager.FindByEmailAsync(email);

            response.UserId = user.Id;
            response.Token = GenerateToken(user);

            return response;
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return;
            }
            
            await _userManager.DeleteAsync(user);
        }

        #endregion
        
        #region Private Methods

        private string GenerateToken(AppUserIdentity user)
        {
            var claims = new List<Claim>();
            var customClaims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id),
                new Claim(ClaimTypes.NameIdentifier, user.AccountId.ToString())
            };

            claims.AddRange(customClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[ConfigurationConstant.JwtKey]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddYears(1),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion
        
    }
}