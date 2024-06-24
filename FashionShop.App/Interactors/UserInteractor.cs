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
	public class UserInteractor
	{
		private IUserRepository repository;
		private IUnitWork unitWork;

		public UserInteractor(IUserRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}

		public async Task<Response> Create(UserDto user)
		{
			var response = new Response<UserDto>();
			try
			{
				await repository.Create(user.ToEntity());
				await unitWork.Commit();
				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = "Внутренняя ошибка!";
				response.ErrorInfo = ex.Message.ToString()+$"\nInner msg: {ex.InnerException.Message.ToString()}";
				response.IsSuccess = false;
			}
			return response;
		}
        public async Task<Response> CreateWithBasket(UserDto user)
        {
            var response = new Response<UserDto>();
            try
            {
				//var userResp = await GetByEmail(user.Email);
				//if (userResp.IsSuccess)
				//{
				//	throw new Exception("An account with the same email already exists!");
				//}
                await repository.CreateWithBasket(user.ToEntity());
                await unitWork.Commit();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.ErrorInfo = ex.Message.ToString() + $"\nInner msg: {ex.InnerException.Message.ToString()}";
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<Response<UserDto>> Read(int id)
		{
			var response = new Response<UserDto>();
			try
			{
				var user = await repository.Read(id);
				response.Value = user.ToDto();
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
        public async Task<Response> AddRole(int userId, int roleId)
        {
            var response = new Response<UserDto>();
            try
            {
                await repository.AddRole(userId, roleId);
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
        public async Task<Response<UserDto>> GetByEmail(string email )
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await repository.GetByEmail(email);
                response.Value = user.ToDto();
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
        public async Task<Response<UserDto>> GetByEmailPassword(string email, string password)
        {
            var response = new Response<UserDto>();
            try
            {
                var user = await repository.GetByEmailPassword(email, password);
				if (user == null) throw new Exception("Пользователь не найден!!!");
                response.Value = user.ToDto();
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
        public async Task<Response<DataPage<UserDto>>> ReadAll()
		{
			var response = new Response<DataPage<UserDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<UserDto> users = new();
				await foreach (var item in data)
				{
					users.Add(item.ToDto());
				}
				response.Value.Data = users.ToArray();
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

		public async Task<Response<DataPage<UserDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<UserDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<UserDto> users = new();
				await foreach (var item in data)
				{
					users.Add(item.ToDto());
				}
				response.Value.Data = users.ToArray();
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

		public async Task<Response> Update(UserDto user)
		{
			var response = new Response<UserDto>();
			try
			{
				await repository.Update(user.ToEntity());
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
			var response = new Response<UserDto>();
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
