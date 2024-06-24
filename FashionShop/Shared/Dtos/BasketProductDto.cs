using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class BasketProductDto
	{
		public int Id { get; set; }
		public int? BasketId { get; set; }
		public int? ProductId { get; set; }
		public BasketDto? Basket { get; set; }
        public SizeDto? SizeProduct { get; set; }
    }
}
