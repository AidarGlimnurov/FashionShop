using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IReviewRepository : IRepository<Review>
	{
        public Task CreateReview(Review review);
        public IAsyncEnumerable<Review> GetByProduct(int productId);
        public Task Edit(Review review);
    }
}
