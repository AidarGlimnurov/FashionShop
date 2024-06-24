using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.Dtos
{
	public class BasketDto
	{
		public int Id { get; set; }
		public int? UserId { get; set; }
		public UserDto? User { get; set; }
	}
}
