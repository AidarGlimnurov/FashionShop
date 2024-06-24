using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class OrderProductDto
	{
		public int Id { get; set; }
		public int? ProductId { get; set; }
		public int? OrderId { get; set; }
		public OrderDto? Order { get; set; }
		public SizeDto? Product { get; set; }
	}
}
