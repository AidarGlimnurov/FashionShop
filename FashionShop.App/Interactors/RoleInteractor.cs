using FashionShop.App.Data;
using FashionShop.App.Mappers;
using FashionShop.App.Storage;
using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Interactors
{
	public class RoleInteractor
	{
		private IRoleRepository repository;
		private IUnitWork unitWork;

		public RoleInteractor(IRoleRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}
		public async Task<Response> Create(RoleDto role)
		{
			var response = new Response<RoleDto>();
			try
			{
				await repository.Create(role.ToEntity());
				await unitWork.Commit();
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}
		public async Task<Response<RoleDto>> Read(int id)
		{
			var response = new Response<RoleDto>();
			try
			{
				var role = await repository.Read(id);
				response.Value = role.ToDto();
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}
		public async Task<Response<DataPage<RoleDto>>> ReadAll()
		{
			var response = new Response<DataPage<RoleDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<RoleDto> roles = new();
				await foreach (var item in data)
				{
					roles.Add(item.ToDto());
				}
				response.Value.Data = roles.ToArray();
				response.IsSuccess = true;
			}

			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}

		public async Task<Response<DataPage<RoleDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<RoleDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<RoleDto> roles = new();
				await foreach (var item in data)
				{
					roles.Add(item.ToDto());
				}
				response.Value.Data = roles.ToArray();
				response.Value.Start = start;
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}

		public async Task<Response> Update(RoleDto role)
		{
			var response = new Response<RoleDto>();
			try
			{
				await repository.Update(role.ToEntity());
				await unitWork.Commit();
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}

		public async Task<Response> Delete(int id)
		{
			var response = new Response<RoleDto>();
			try
			{
				await repository.Delete(id);
				await unitWork.Commit();
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString();
				response.IsSuccess = false;
			}
			return response;
		}
	}
}
