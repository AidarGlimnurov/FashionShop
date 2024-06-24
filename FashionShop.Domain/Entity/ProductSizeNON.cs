using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
    public class ProductSize
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public SizeProduct Size { get; set; }
    }
}
