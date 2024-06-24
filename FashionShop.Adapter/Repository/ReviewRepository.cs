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
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ShopContext context) : base(context)
        {

        }

        public async Task CreateReview(Review review)
        {
            review.Product = await context.Products.FirstOrDefaultAsync(p => p.Id == review.ProductId);
            review.User = await context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);

            context.Add(review);
        }

        public async Task Edit(Review review)
        {
            var rev = await context.Reviews.FirstOrDefaultAsync(r => r.Id == review.Id);
            rev.Product = await context.Products.FirstOrDefaultAsync(p => p.Id == review.ProductId);
            rev.User = await context.Users.FirstOrDefaultAsync(u => u.Id == review.UserId);
            context.Update(rev);
        }

        public async IAsyncEnumerable<Review> GetByProduct(int productId)
        {
            var products = context.Reviews.Include(r => r.User).Where(r => r.ProductId == productId);

            foreach (var product in products)
            {
                yield return product;
            }
        }
    }
}
