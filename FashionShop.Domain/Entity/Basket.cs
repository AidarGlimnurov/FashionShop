using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
	public class Basket
	{
		public int Id { get; set; }
		public int? UserId { get; set; }
		public User? User { get; set; }
	}
}
