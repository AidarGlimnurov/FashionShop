using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class OrderProductMapper
	{
		public static OrderProductDto ToDto(this OrderProduct orderProduct)
		{
			return new OrderProductDto
			{
				Id = orderProduct.Id,
				Order = orderProduct.Order.ToDto(),
				OrderId = orderProduct.OrderId,
				Product = orderProduct.Product.ToDto(),
				ProductId = orderProduct.ProductId,
			};
		}

		public static OrderProduct ToEntity(this OrderProductDto orderProductDto)
		{
			return new OrderProduct
			{
				Id = orderProductDto.Id,
				Order = orderProductDto.Order.ToEntity(),
				OrderId = orderProductDto.OrderId,
				Product = orderProductDto.Product.ToEntity(),
				ProductId = orderProductDto.ProductId,
			};
		}
	}
}
