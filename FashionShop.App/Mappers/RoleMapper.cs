using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
	public static class RoleMapper
	{
		public static RoleDto ToDto(this Role role)
		{
			return new RoleDto
			{
				Id = role.Id,
				Name = role.Name,
			};
		}

		public static Role ToEntity(this RoleDto roleDto)
		{
			return new Role
			{
				Id = roleDto.Id,
				Name = roleDto.Name,
			};
		}
	}
}