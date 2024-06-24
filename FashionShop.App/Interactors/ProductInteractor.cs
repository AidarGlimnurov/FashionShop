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
	public class ProductInteractor
	{
		private IProductRepository repository;
		private IUnitWork unitWork;

		public ProductInteractor(IProductRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}

		public async Task<Response> Create(ProductDto product)
		{
			var response = new Response<ProductDto>();
			try
			{
				await repository.Create(product.ToEntity());
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
		public async Task<Response<ProductDto>> Read(int id)
		{
			var response = new Response<ProductDto>();
			try
			{
				var product = await repository.Read(id);
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
        public async Task<Response> AddTag(int tagId, int productId)
        {
            var response = new Response<ProductDto>();
            try
            {
                await repository.AddTag(productId, tagId);
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
        public async Task<Response> AddSize(int sizeId, int productId)
        {
            var response = new Response<ProductDto>();
            try
            {
                await repository.AddSize(productId, sizeId);
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
        public async Task<Response> RemoveSize(int sizeId, int productId)
        {
            var response = new Response<ProductDto>();
            try
            {
                await repository.RemoveSize(productId, sizeId);
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
        public async Task<Response> RemoveTag(int tagId, int productId)
        {
            var response = new Response<ProductDto>();
            try
            {
                await repository.RemoveSize(productId, tagId);
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
        public async Task<Response<IEnumerable<SizeDto>>> GetSizes(int productId)
        {
            var response = new Response<IEnumerable<SizeDto>>();
            try
            {
                var data = repository.GetSizes(productId);

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
        public async Task<Response<IEnumerable<TagDto>>> GetTags(int productId)
        {
            var response = new Response<IEnumerable<TagDto>>();
            try
            {
                var data = repository.GetTags(productId);

                List<TagDto> tags = new();
                await foreach (var item in data)
                {
                    tags.Add(item.ToDto());
                }
                response.Value = tags.ToList();
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
        public async Task<Response<IEnumerable<ProductDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ProductDto>>();
            try
            {
                var data = repository.GetAll();

                List<ProductDto> products = new();
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
        public async Task<Response<IEnumerable<ProductDto>>> GetByTag(int tagId)
        {
            var response = new Response<IEnumerable<ProductDto>>();
            try
            {
                var data = repository.GetByTag(tagId);

                List<ProductDto> products = new();
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
        public async Task<Response<DataPage<ProductDto>>> ReadAll()
		{
			var response = new Response<DataPage<ProductDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<ProductDto> products = new();
				await foreach (var item in data)
				{
					products.Add(item.ToDto());
				}
				response.Value.Data = products.ToArray();
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
		public async Task<Response<DataPage<ProductDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<ProductDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<ProductDto> products = new();
				await foreach (var item in data)
				{
					products.Add(item.ToDto());
				}
				response.Value.Data = products.ToArray();
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
		public async Task<Response> Update(ProductDto product)
		{
			var response = new Response<ProductDto>();
			try
			{
				await repository.Update(product.ToEntity());
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
			var response = new Response<ProductDto>();
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
