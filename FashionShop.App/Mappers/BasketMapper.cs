using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class BasketMapper
	{
		public static BasketDto ToDto(this Basket basket)
		{
			var basketDto = new BasketDto
			{
				Id = basket.Id,
				UserId = basket?.UserId,
				User = basket.User?.ToDto(),
			};

			return basketDto;
		}

		public static Basket ToEntity(this BasketDto basketDto)
		{
			var basket = new Basket
			{
				Id = basketDto.Id,
				User = basketDto.User?.ToEntity(),
				UserId = basketDto?.UserId,
			};

			return basket;
		}
	}
}
