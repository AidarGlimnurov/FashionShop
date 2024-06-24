using FashionShop.App.Interactors;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using static IdentityServer4.Models.IdentityResources;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace FashionShop.Server.Controllers.ShopPart
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserInteractor interactor;
        private EmailVerifInteractor verifInteractor;
        public UserController(UserInteractor interactor, EmailVerifInteractor verifInteractor)
        {
            this.interactor = interactor;
            this.verifInteractor = verifInteractor;
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("getlogin")]
        public Task<string> GetLogin()
        {
            string str = "12345";
            return Task.FromResult(str);
        }
        [Authorize]
        [HttpGet("GetUserInfo")]
        public async Task<Response<UserDto>> GetUserId()
        {
            // Извлекаем ID пользователя из Claims
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            var a = 1;
            var user = await interactor.GetByEmail(email);
            user.Value.Password = string.Empty;
            return user;
        }
        [HttpGet("GetCode")]
        public async Task<Response> GetCode(string email)
        {
            Response resp = new();
            try
            {
                //var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
                resp = await verifInteractor.CreateWithEmail(email);
                if (resp.IsSuccess)
                {
                    var code = resp.Info;
                    using var emailMessage = new MimeMessage();

                    string subject = "Потдверждение почты";
                    string message = "<h2>Благодарим Вас за регистрацию на нашем сайте</h2>" +
                        "<br>" +
                        "<span>Ваш код для подтверждения почты</span>" +
                        "<br>" +
                        $"<strong>{code}<strong>" +
                        "<br>" +
                        "<strong>Никому его не сообщайте!</strong>";

                    emailMessage.From.Add(new MailboxAddress("FashionShop Administration", "0ivanovivan00@mail.ru"));
                    emailMessage.To.Add(new MailboxAddress("", email));
                    emailMessage.Subject = subject;
                    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    {
                        Text = message,
                    };

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                        await client.ConnectAsync("smtp.mail.ru", 465, true);
                        await client.AuthenticateAsync("0ivanovivan00@mail.ru", "1xcgjmZm97Jj3XSJC2Rw");
                        await client.SendAsync(emailMessage);

                        await client.DisconnectAsync(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Не удалось отправить письмо!",
                };
            }
            resp.Info = "Письмо успешно отправлено! Проверьте почту!";
            return resp;
        }
        [HttpPost("CreateWithCode")]
        public async Task<Response> CreateWithCode(UserDto user)
        {
            var resp = await verifInteractor.Verification(user.Email, user.code);
            if (resp.IsSuccess)
            {
                return await interactor.CreateWithBasket(user);
            }
            return new Response()
            {
                ErrorInfo = resp.ErrorInfo,
                ErrorMessage = resp.ErrorMessage,
                IsSuccess = resp.IsSuccess,
                Info = resp.Info,
            };
        }

        [HttpPost("CreateWithBasket")]
        public async Task<Response> CreateWithBasket(UserDto user)
        {
            return await interactor.CreateWithBasket(user);
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] UserDto user)
        {
            return await interactor.Create(user);
        }
        [HttpGet("Read")]
        public async Task<Response<UserDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpGet("ReadAll")]
        public async Task<Response<DataPage<UserDto>>> ReadAll()
        {
            return await interactor.ReadAll();
        }
        [HttpGet("ReadPage")]
        public async Task<Response<DataPage<UserDto>>> ReadPage(int start, int count)
        {
            return await interactor.ReadPage(start, count);
        }
        [HttpGet("Update")]
        public async Task<Response> Update([FromBody] UserDto user)
        {
            return await interactor.Update(user);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("AddRole")]
        public async Task<Response> AddRole(int userId, int roleId)
        {
            return await interactor.AddRole(userId, roleId);
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
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Value.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Value.Role.Name),
                    new Claim("UserId", person.Value.Id.ToString()),
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
