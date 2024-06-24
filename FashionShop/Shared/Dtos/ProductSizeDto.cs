using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
    public class ProductSizeDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public SizeDto Size { get; set; }
    }
}
