using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
    public static class TagMapper
    {
        public static TagDto ToDto(this Tag tag)
        {
            var tagDto = new TagDto
            {
                Id = tag.Id,
                Name = tag.Name,
            };

            return tagDto;
        }

        public static Tag ToEntity(this TagDto tagDto)
        {
            var tag = new Tag
            {
                Id = tagDto.Id,
                Name = tagDto.Name,
            };

            return tag;
        }
    }
}
