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
    public class SizeRepository : BaseRepository<SizeProduct>, ISizeRepository
    {
        public SizeRepository(ShopContext context) : base(context)
        {

        }

        public async Task CreateWithEntity(SizeProduct size)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == size.ProductId);
            size.Product = product;
            context.Add(size);
        }

        public async IAsyncEnumerable<SizeProduct> GetAll()
        {
            var sizes = await context.Sizes.ToArrayAsync();

            foreach (var size in sizes)
            {
                yield return size;
            }
        }

        public async IAsyncEnumerable<SizeProduct> GetForProduct(int ProductId)
        {
            var sizes = await context.Sizes.Include(s=>s.Product).Where(s=>s.ProductId==ProductId).ToArrayAsync();

            foreach (var size in sizes)
            {
                yield return size;
            }
        }

        public async Task<SizeProduct> GetSize(int sizeId)
        {
            var size = await context.Sizes.Include(s => s.Product).FirstOrDefaultAsync(s => s.Id == sizeId);
            return size;
        }

        public async Task UpdateWithEntity(SizeProduct size)
        {
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == size.ProductId);
            size.Product = product;
            context.Update(size);
        }
    }
}
