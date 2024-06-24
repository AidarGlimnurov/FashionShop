using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
	public class BasketProduct
	{
		public int Id { get; set; }
		public int? BasketId { get; set; }
		public int? ProductId { get; set; }
		public Basket? Basket { get; set; }
		public SizeProduct? SizeProduct{ get; set; }
	}
}
