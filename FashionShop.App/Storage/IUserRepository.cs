using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IUserRepository : IRepository<User>
	{
		public Task<User> GetByEmailPassword(string email, string password);
		public Task<User> GetByEmail(string email);
        public Task CreateWithBasket(User user);
        public Task AddRole(int userId, int roleId);
    }
}
