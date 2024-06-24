using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
	public class Review
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public bool IsEdit { get; set; } = false;

		public int? UserId { get; set; }
		public User? User { get; set; }
		public int? ProductId { get; set; }
		public Product? Product { get; set; }
	}
}
