using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
    public static class EmailVerifMapper
    {
        public static EmailVerifDto? ToDto(this EmailVerif emailVerif)
        {
            if (emailVerif == null)
            {
                return null;
            }

            EmailVerifDto emailVerifDto = new EmailVerifDto()
            {
                Id = emailVerif.Id,
                Email = emailVerif.Email,
                Code = emailVerif.Code,
                IsAcivate = emailVerif.IsAcivate,
                CreatAt = emailVerif.CreatAt,
            };

            return emailVerifDto;
        }

        public static EmailVerif? ToEntity(this EmailVerifDto emailVerifDto)
        {
            if (emailVerifDto == null)
            {
                return null;
            }

            EmailVerif emailVerif = new EmailVerif()
            {
                Id = emailVerifDto.Id,
                Email = emailVerifDto.Email,
                Code = emailVerifDto.Code,
                IsAcivate = emailVerifDto.IsAcivate,
                CreatAt = emailVerifDto.CreatAt,
            };

            return emailVerif;
        }
    }
}
