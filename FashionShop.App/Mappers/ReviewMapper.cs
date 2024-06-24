using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class ReviewMapper
	{
		public static ReviewDto ToDto(this Review review)
		{
			return new ReviewDto
			{
				Id = review.Id,
				Content = review.Content,
				IsEdit = review.IsEdit,
				UserId = review?.UserId,
				ProductId = review?.ProductId,
				User = review.User?.ToDto(),
				Product = review.Product?.ToDto()
			};
		}

		public static Review ToEntity(this ReviewDto reviewDto)
		{
			return new Review
			{
				Id = reviewDto.Id,
				Content = reviewDto.Content,
				IsEdit = reviewDto.IsEdit,
				UserId = reviewDto?.UserId,
				ProductId = reviewDto?.ProductId,
				User = reviewDto.User?.ToEntity(),
				Product = reviewDto.Product?.ToEntity()
			};
		}
	}
}
