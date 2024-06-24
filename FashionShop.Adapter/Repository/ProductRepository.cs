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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }

        public async Task AddSize(int productId, int sizeId)
        {
            var size = await context.Sizes.FirstOrDefaultAsync(t => t.Id == sizeId);
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            ProductSize productSize = new()
            {
                Size = size,
                Product = product,
            };
            context.Add(productSize);
        }

        public async Task AddTag(int productId, int tagId)
        {
            var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == tagId);
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            ProductTag productTag = new()
            {
                Tag = tag,
                Product = product,
            };
            context.ProductTags.Add(productTag);
        }

        public async IAsyncEnumerable<Product> GetAll()
        {
            var products = await context.Products.ToArrayAsync();

            foreach (var product in products)
            {
                yield return product;
            }
        }

        public async IAsyncEnumerable<Product> GetByTag(int tagId)
        {
            var productTags = await context.ProductTags.Include(pt => pt.Product).Where(pt => pt.Tag.Id == tagId).ToArrayAsync();
            foreach (var productTag in productTags)
            {
                yield return productTag.Product;
            }
        }

        public async IAsyncEnumerable<SizeProduct> GetSizes(int productId)
        {
            var productSizes = await context.Sizes.Include(ps => ps.Product).
                Where(ps => ps.Product.Id == productId).ToArrayAsync();
            foreach (var productSize in productSizes)
            {
                yield return productSize;
            }
        }

        public async IAsyncEnumerable<Tag> GetTags(int productId)
        {
            var productTags = await context.ProductTags.Include(pt => pt.Product).Include(pt => pt.Tag)
                .Where(ps => ps.Product.Id == productId).ToArrayAsync();
            foreach (var productTag in productTags)
            {
                yield return productTag.Tag;
            }
        }
        public async Task RemoveSize(int productId, int sizeId)
        {
            var sizeProduct = await context.ProductSizes.Include(s => s.Product).Include(s => s.Size)
                .FirstOrDefaultAsync(s => s.Product.Id == productId && s.Size.Id == sizeId);
            context.Remove(sizeProduct);
        }

        public async Task RemoveTag(int productId, int tagId)
        {
            var tagProduct = await context.ProductTags.Include(t => t.Product).Include(t => t.Tag)
                .FirstOrDefaultAsync(t => t.Product.Id == productId && t.Tag.Id == tagId);
            context.Remove(tagProduct);
        }
    }
}
