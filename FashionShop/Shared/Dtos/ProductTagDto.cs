using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
    public class ProductTagDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public TagDto Tag { get; set; }
    }
}
