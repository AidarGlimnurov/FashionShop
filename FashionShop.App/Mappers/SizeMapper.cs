using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
    public static class SizeMapper
    {
        public static SizeDto ToDto(this SizeProduct size)
        {
            return new SizeDto
            {
                Id = size.Id,
                Amount = size.Amount,
                Letter = size.Letter,
                Description = size.Description,
                Price = size.Price,
                Quantity = size.Quantity,
                ProductId = size.ProductId,
                Product = size.Product?.ToDto(),
            };
        }

        public static SizeProduct ToEntity(this SizeDto sizeDto)
        {
            return new SizeProduct
            {
                Id = sizeDto.Id,
                Amount = sizeDto.Amount,
                Letter = sizeDto.Letter,
                Description = sizeDto.Description,
                Price = sizeDto.Price,
                Quantity = sizeDto.Quantity,
                ProductId = sizeDto.ProductId,
                Product = sizeDto.Product?.ToEntity(),
            };
        }
    }
}
