using FashionShop.App.Storage;
using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Adapter.Repository
{
    public class ProductSizeRepository: BaseRepository<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(ShopContext context) : base(context)
        {

        }
    }
}
