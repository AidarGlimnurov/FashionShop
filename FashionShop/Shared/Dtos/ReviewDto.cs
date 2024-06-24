using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class ReviewDto
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public bool IsEdit { get; set; } = false;

		public int? UserId { get; set; }
		public UserDto User { get; set; }
		public int? ProductId { get; set; }
		public ProductDto Product { get; set; }
	}
}
