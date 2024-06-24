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
	public class BasketInteractor
	{
		private IBasketRepository repository;
		private IUnitWork unitWork;

		public BasketInteractor(IBasketRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}

		public async Task<Response> Create(BasketDto basket)
		{
			var response = new Response<BasketDto>();
			try
			{
				await repository.Create(basket.ToEntity());
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
        public async Task<Response<IEnumerable<SizeDto>>> GetForUser(int userId)
        {
            var response = new Response<IEnumerable<SizeDto>>();
            try
            {
                var data = repository.GetForUser(userId);

                List<SizeDto> products = new();
                await foreach (var item in data)
                {
                    products.Add(item.ToDto());
                }
                response.Value = products.ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Внутренняя ошибка!";
                response.IsSuccess = false;
                response.ErrorInfo = ex.Message;
            }
            return response;
        }
        public async Task<Response<BasketDto>> Read(int id)
		{
			var response = new Response<BasketDto>();
			try
			{
				var order = await repository.Read(id);

				response.Value = order.ToDto();
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
		public async Task<Response<DataPage<BasketDto>>> ReadAll()
		{
			var response = new Response<DataPage<BasketDto>>();
			try
			{
				var data = await repository.ReadAll();

				List<BasketDto> orders = new();
				await foreach (var item in data)
				{
					orders.Add(item.ToDto());
				}
				response.Value.Data = orders.ToArray();
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
		public async Task<Response<DataPage<BasketDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<BasketDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);

				List<BasketDto> orders = new();
				await foreach (var item in data)
				{
					orders.Add(item.ToDto());
				}
				response.Value.Data = orders.ToArray();
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
		public async Task<Response> Update(BasketDto basket)
		{
			var response = new Response<BasketDto>();
			try
			{
				await repository.Update(basket.ToEntity());
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
			var response = new Response<BasketDto>();
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
        public async Task<Response> AddInBasket(int userId, int productId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await repository.AddInBasket(userId, productId);
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
        public async Task<Response> CreateBasketForUser(int userId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await repository.CreateBasketForUser(userId);
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
        public async Task<Response> RemoveInBasket(int userId, int productId)
        {
            var response = new Response<BasketDto>();
            try
            {
                await repository.RemoveInBasket(userId, productId);
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
        public async Task<Response<SizeDto>> GetProduct(int userId, int productId)
        {
            var response = new Response<SizeDto>();
            try
            {
                var product = await repository.GetProduct(userId, productId);

                response.Value = product.ToDto();
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
