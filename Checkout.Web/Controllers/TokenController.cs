using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Checkout.Core.Models.Account;
using Checkout.Core.Services.Interfaces;
using Checkout.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Checkout.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IMerchantService _IMerchantService;

        public TokenController(IConfiguration config, IMerchantService IMerchantService)
        {
            _configuration = config;
            _IMerchantService = IMerchantService;
        }

        [HttpPost]
        public IActionResult Post(TokenRequestModel tokenRequest)
        {

            if ( tokenRequest != null && !string.IsNullOrEmpty(tokenRequest.ApiKey))
            {
                var user = _IMerchantService.GetMerchantProfile(tokenRequest.ApiKey);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("ProfileId", user.Id.ToString()),
                    new Claim("Name", user.Name),
                    new Claim("UserName", user.Merchant.Email),
                    new Claim("APIMode", user.Mode == Core.Models.Common.APIMode.Live ? "1" :"0")
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddMinutes(10), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}