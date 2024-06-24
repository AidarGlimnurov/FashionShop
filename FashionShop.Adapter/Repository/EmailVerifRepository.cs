using FashionShop.App.Storage;
using FashionShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Adapter.Repository
{
    public class EmailVerifRepository : BaseRepository<EmailVerif>, IEmailVerifRepository
    {
        public EmailVerifRepository(ShopContext context) : base(context)
        {
        }

        public async Task CreateWithEmail(string email, string code)
        {
            EmailVerif emailVerif = new()
            {
                Email = email,
                Code = code,
                IsAcivate = false,
            };
            await context.AddAsync(emailVerif);
        }

        public async Task<EmailVerif> Verification(string email, string code)
        {
            var emailVerif = await context.EmailVerifs.FirstOrDefaultAsync(e => e.Email == email && e.Code == code);
            if (emailVerif != null)
            {
                //var user = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
                //user.IsVerified = true;
                //context.Update(user);
                //context.SaveChanges();
                return emailVerif;
            }
            throw new NotImplementedException("Ключ не верен!");
        }
    }
}
