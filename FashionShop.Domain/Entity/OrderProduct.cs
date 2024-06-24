using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
	public class OrderProduct
	{
		public int Id { get; set; }
		public int? ProductId { get; set; }
		public int? OrderId { get; set; }
		public Order? Order { get; set; }
		public SizeProduct? Product { get; set; }
	}
}
