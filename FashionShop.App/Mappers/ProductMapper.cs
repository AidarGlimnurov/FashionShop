using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product product)
        {
            if (product == null) throw new ArgumentNullException();
            var productDto = new ProductDto
            {
                Id = product.Id,
                Cover = product.Cover,
                Img1= product.Img1,
                Img2= product.Img2,
                Img3= product.Img3,
                Description = product.Description,
                Name = product.Name,

            };

            return productDto;
        }

        public static Product ToEntity(this ProductDto productDto)
        {
            if (productDto == null) throw new ArgumentNullException();
            var product = new Product
            {
                Id = productDto.Id,
                Cover = productDto.Cover,
                Img1 = productDto.Img1,
                Img2 = productDto.Img2,
                Img3 = productDto.Img3,
                Description = productDto.Description,
                Name = productDto.Name,

            };

            return product;
        }
    }
}
