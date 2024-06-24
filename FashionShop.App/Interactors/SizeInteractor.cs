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
	public class SizeInteractor
	{
		private ISizeRepository repository;
		private IUnitWork unitWork;

		public SizeInteractor(ISizeRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}
		public async Task<Response> Create(SizeDto size)
		{
			var response = new Response<SizeDto>();
			try
			{
				await repository.Create(size.ToEntity());
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
        public async Task<Response> CreateWithEntity(SizeDto size)
        {
            var response = new Response<SizeDto>();
            try
            {
                await repository.CreateWithEntity(size.ToEntity());
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
        public async Task<Response<SizeDto>> Read(int id)
		{
			var response = new Response<SizeDto>();
			try
			{
				var size = await repository.Read(id);
				response.Value = size.ToDto();
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
        public async Task<Response<SizeDto>> GetSize(int sizeId)
        {
            var response = new Response<SizeDto>();
            try
            {
                var size = await repository.GetSize(sizeId);
                response.Value = size.ToDto();
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
        public async Task<Response<DataPage<SizeDto>>> ReadAll()
		{
			var response = new Response<DataPage<SizeDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<SizeDto> sizes = new();
				await foreach (var item in data)
				{
					sizes.Add(item.ToDto());
				}
				response.Value.Data = sizes.ToArray();
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
		public async Task<Response<DataPage<SizeDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<SizeDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<SizeDto> sizes = new();
				await foreach (var item in data)
				{
					sizes.Add(item.ToDto());
				}
				response.Value.Data = sizes.ToArray();
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
		public async Task<Response> Update(SizeDto size)
		{
			var response = new Response<SizeDto>();
			try
			{
				await repository.Update(size.ToEntity());
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
        public async Task<Response> UpdateWithEntity(SizeDto size)
        {
            var response = new Response<SizeDto>();
            try
            {
                await repository.UpdateWithEntity(size.ToEntity());
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
			var response = new Response<SizeDto>();
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
        public async Task<Response<IEnumerable<SizeDto>>> GetAll()
        {
            var response = new Response<IEnumerable<SizeDto>>();
            try
            {
                var data = repository.GetAll();

                List<SizeDto> sizes = new();
                await foreach (var item in data)
                {
                    sizes.Add(item.ToDto());
                }
                response.Value = sizes.ToList();
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
        public async Task<Response<IEnumerable<SizeDto>>> GetForProduct(int ProductId)
        {
            var response = new Response<IEnumerable<SizeDto>>();
            try
            {
                var data = repository.GetForProduct(ProductId);

                List<SizeDto> sizes = new();
                await foreach (var item in data)
                {
                    sizes.Add(item.ToDto());
                }
                response.Value = sizes.ToList();
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
    }
}
