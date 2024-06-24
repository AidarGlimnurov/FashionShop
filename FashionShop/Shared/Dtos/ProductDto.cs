using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class ProductDto
	{
		public int Id { get; set; }
		public byte[] Cover { get; set; }
        public byte[] Img1 { get; set; }
        public byte[] Img2 { get; set; }
        public byte[] Img3 { get; set; }
        public string Description { get; set; }
		public string Name { get; set; }
	}
}
