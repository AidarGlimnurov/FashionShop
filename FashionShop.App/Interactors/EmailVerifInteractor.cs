using FashionShop.App.Data;
using FashionShop.App.Mappers;
using FashionShop.App.Storage;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Interactors
{
    public class EmailVerifInteractor
    {
        private IEmailVerifRepository emailVerifRepository;
        private IUnitWork unitWork;

        public EmailVerifInteractor(IEmailVerifRepository emailVerifRepository, IUnitWork unitWork)
        {
            this.emailVerifRepository = emailVerifRepository;
            this.unitWork = unitWork;
        }

        public async Task<Response> CreateWithEmail(string email)
        {
            var response = new Response<EmailVerifDto>();
            try
            {
                Random random = new Random();
                var code = random.Next(100000, 1000000).ToString();
                await emailVerifRepository.CreateWithEmail(email, code);
                await unitWork.Commit();
                return new Response() { IsSuccess = true, Info = code };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка создания"
                };
            }
        }
        public async Task<Response<EmailVerifDto>> Verification(string email, string code)
        {
            var response = new Response<EmailVerifDto>();
            try
            {
                Random random = new Random();
                var emailVerif = await emailVerifRepository.Verification(email, code);
                if (emailVerif != null)
                {
                    await emailVerifRepository.Delete(emailVerif.Id);
                }
                await unitWork.Commit();
                return new Response<EmailVerifDto>()
                {
                    IsSuccess = true,
                    Value = emailVerif.ToDto()
                };
            }
            catch (Exception ex)
            {
                return new Response<EmailVerifDto>()
                {
                    IsSuccess = false,
                    ErrorInfo = ex.Message,
                    ErrorMessage = "Ошибка верификации"
                };
            }
        }
    }
}
