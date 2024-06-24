using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface ISizeRepository : IRepository<SizeProduct>
	{
        public Task CreateWithEntity (SizeProduct size);
        public Task UpdateWithEntity (SizeProduct size);
        public IAsyncEnumerable<SizeProduct> GetAll();
        public Task<SizeProduct> GetSize(int sizeId);
        public IAsyncEnumerable<SizeProduct> GetForProduct(int ProductId);
    }
}
