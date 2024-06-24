using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
    public interface IEmailVerifRepository : IRepository<EmailVerif>
    {
        public Task CreateWithEmail(string email, string code);
        public Task<EmailVerif> Verification(string email, string code);
    }
}
