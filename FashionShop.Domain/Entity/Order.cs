using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Domain.Entity
{
	public class Order
	{
		public int Id { get; set; }
		public string Index { get; set; }
		public string Fio { get; set; }
		public string Adress { get; set; }
		public string Status { get; set; }
        public int? UserId { get; set; }
		public User? User { get; set; }
	}
}
