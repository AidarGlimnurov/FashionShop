using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class UserMapper
	{
		public static UserDto ToDto(this User user)
		{
			return new UserDto
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				Password = user.Password,
				RoleId = user.RoleId,
				Role = user.Role?.ToDto(),
			};
		}

		public static User ToEntity(this UserDto userDto)
		{
			return new User
			{
				Id = userDto.Id,
				Name = userDto.Name,
				Email = userDto.Email,
				Password = userDto.Password,
				RoleId = userDto.RoleId,
				Role = userDto.Role?.ToEntity(),
			};
		}
	}
}
