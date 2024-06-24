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
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ShopContext context) : base(context)
        {

        }

        public async Task AddInBasket(int userId, int productId)
        {
            var product = await context.Sizes.FirstOrDefaultAsync(p => p.Id == productId);
            var basket = await context.Baskets.Include(b => b.User).FirstOrDefaultAsync(b => b.UserId == userId);
            BasketProduct basketProduct = new()
            {
                SizeProduct = product,
                Basket = basket,
            };
            context.Add(basketProduct);
        }

        public async Task CreateBasketForUser(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            Basket basket = new()
            {
                User = user
            };
            context.Add(basket);
        }

        public async IAsyncEnumerable<SizeProduct> GetForUser(int userId)
        {
            var products = await context.BasketProducts.Include(bp => bp.Basket).ThenInclude(b => b.User)
                .Include(bp => bp.SizeProduct).ThenInclude(s => s.Product).Where(bp => bp.Basket.User.Id == userId).ToArrayAsync();
            foreach (var product in products)
            {
                yield return product.SizeProduct;
            }
        }

        public async Task<SizeProduct> GetProduct(int userId, int productId)
        {
            var basketProduct = await context.BasketProducts.Include(bp => bp.SizeProduct)
                .FirstOrDefaultAsync(bp => bp.SizeProduct.Id == productId && bp.Basket.User.Id == userId);
            if (basketProduct != null)
            {
                return basketProduct.SizeProduct;
            }
            throw new Exception("Продукта в корзине нет!");
        }

        public async Task RemoveInBasket(int userId, int productId)
        {
            var basketProduct = await context.BasketProducts.Include(bp => bp.Basket).Include(bp => bp.SizeProduct)
                .FirstOrDefaultAsync(bp => bp.SizeProduct.Id == productId && bp.Basket.User.Id == userId);
            context.Remove(basketProduct);
        }
    }
}
