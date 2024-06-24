using FashionShop.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using FashionShop.Shared.Dtos;
using FashionShop.App.Interactors;
using System.Threading.Tasks;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace FashionShop.Server.Controllers.ShopPart
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserInteractor interactor;
        public AccountController(UserInteractor interactor)
        {
            this.interactor = interactor;
        }

        [Authorize]
        [HttpGet("GetUserInfo")]
        public async Task<Response<UserDto>> GetUserId()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            var a = 1;
            var user = await interactor.GetByEmail(email);
            user.Value.Password = string.Empty;
            user.IsSuccess = true;
            return user;
        }
        [HttpPost("token")]
        public async Task<IActionResult> Token(UserDto userPerson)//string username, string password)
        {
            var identity = await GetIdentity(userPerson.Email, userPerson.Password);//(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Ok(response);
        }
        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var person = await interactor.GetByEmailPassword(username, password);// .FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null && person.IsSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Value.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Value.Role.Name)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
