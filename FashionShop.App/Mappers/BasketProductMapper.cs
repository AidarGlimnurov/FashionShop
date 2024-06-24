using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class BasketProductMapper
	{
		public static BasketProductDto ToDto(this BasketProduct basketProduct)
		{
			return new BasketProductDto
			{
				Id = basketProduct.Id,
				Basket = basketProduct.Basket.ToDto(),
				BasketId = basketProduct.BasketId,
				SizeProduct = basketProduct.SizeProduct.ToDto(),
				ProductId = basketProduct.ProductId,
			};
		}

		public static BasketProduct ToEntity(this BasketProductDto basketProductDto)
		{
			return new BasketProduct
			{
				Id = basketProductDto.Id,
				Basket = basketProductDto.Basket.ToEntity(),
				BasketId = basketProductDto.BasketId,
				SizeProduct = basketProductDto.SizeProduct.ToEntity(),
				ProductId = basketProductDto.ProductId,
			};
		}
	}
}
