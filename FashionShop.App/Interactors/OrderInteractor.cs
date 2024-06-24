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
	public class OrderInteractor
	{
		private IOrderRepository repository;
		private IUnitWork unitWork;

		public OrderInteractor(IOrderRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}

		public async Task<Response> Create(OrderDto order)
		{
			var response = new Response<OrderDto>();
			try
			{
				await repository.Create(order.ToEntity());
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
		public async Task<Response<OrderDto>> Read(int id)
		{
			var response = new Response<OrderDto>();
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
		public async Task<Response<DataPage<OrderDto>>> ReadAll()
		{
			var response = new Response<DataPage<OrderDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<OrderDto> orders = new();
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
		public async Task<Response<DataPage<OrderDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<OrderDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<OrderDto> orders = new();
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
		public async Task<Response> Update(OrderDto order)
		{
			var response = new Response<OrderDto>();
			try
			{
				await repository.Update(order.ToEntity());
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
			var response = new Response<OrderDto>();
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

        public async Task<Response<IEnumerable<OrderDto>>> GetAll()
        {
            var response = new Response<IEnumerable<OrderDto>>();
            try
            {
                var data = repository.GetAll();

                List<OrderDto> products = new();
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
        public async Task<Response<IEnumerable<OrderDto>>> GetForUser(int userId)
        {
            var response = new Response<IEnumerable<OrderDto>>();
            try
            {
                var data = repository.GetForUser(userId);

                List<OrderDto> products = new();
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
        public async Task<Response<IEnumerable<OrderProductDto>>> Get(int id)
        {
            var response = new Response<IEnumerable<OrderProductDto>>();
            try
            {
				var data = repository.Get(id);

                List<OrderProductDto> products = new();
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

        public async Task<Response> CreateOrder(OrderDto order, int[] allId)
        {
            var response = new Response<OrderDto>();
            try
            {
                await repository.CreateOrder(order.ToEntity(), allId);
                //await unitWork.Commit();
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
        public async Task<Response> UpdateOrder(OrderDto order)
        {
            var response = new Response<OrderDto>();
            try
            {
                await repository.UpdateOrder(order.ToEntity());
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