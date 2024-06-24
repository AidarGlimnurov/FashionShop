using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IProductRepository : IRepository<Product> 
	{
        public IAsyncEnumerable<Product> GetAll();
        public IAsyncEnumerable<Product> GetByTag(int tagId);
        public IAsyncEnumerable<SizeProduct> GetSizes(int productId);
        public IAsyncEnumerable<Tag> GetTags(int productId);
        public Task AddTag(int productId, int tagId);
        public Task RemoveTag(int productId, int tagId);
        public Task AddSize(int productId, int sizeId);
        public Task RemoveSize(int productId, int sizeId);
    }
}
