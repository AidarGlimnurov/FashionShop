using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class OrderDto
	{
		public int Id { get; set; }
        public string Index { get; set; }
        public string Fio { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public int[] AllId { get; set; }
        public int? UserId { get; set; }
		public UserDto User { get; set; }
	}
}
