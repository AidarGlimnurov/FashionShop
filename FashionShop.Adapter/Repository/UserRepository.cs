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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

        public async Task AddRole(int userId, int roleId)
        {
            var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            user.Role = role;
        }

        public async Task CreateWithBasket(User user)
        {
            Basket basket = new()
            {
                User = user,
            };
            var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
            user.Role = role;
            context.Add(user);
            context.Add(basket);
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public  async Task<User> GetByEmailPassword(string email, string password)
        {
            var user = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }
    }
}
