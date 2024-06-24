using FashionShop.App.Storage;
using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Adapter.Repository
{
    public class ProductTagRepositoy: BaseRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepositoy(ShopContext context) : base(context)
        {

        }
    }
}
