using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IBasketRepository : IRepository<Basket>
	{
        public IAsyncEnumerable<SizeProduct> GetForUser(int userId);
        public Task AddInBasket(int userId, int productId);
        public Task CreateBasketForUser(int userId);
        public Task RemoveInBasket(int userId, int productId);
        public Task<SizeProduct> GetProduct(int userId, int productId);
    }
}
