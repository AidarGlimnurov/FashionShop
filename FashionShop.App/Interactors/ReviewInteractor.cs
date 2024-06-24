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
	public class ReviewInteractor
	{
		private IReviewRepository repository;
		private IUnitWork unitWork;

		public ReviewInteractor(IReviewRepository repository, IUnitWork unitWork)
		{
			this.repository = repository;
			this.unitWork = unitWork;
		}

		public async Task<Response> Create(ReviewDto review)
		{
			var response = new Response<ReviewDto>();
			try
			{
				await repository.Create(review.ToEntity());
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
		public async Task<Response<ReviewDto>> Read(int id)
		{
			var response = new Response<ReviewDto>();
			try
			{
				var review = await repository.Read(id);
				response.Value = review.ToDto();
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
		public async Task<Response<DataPage<ReviewDto>>> ReadAll()
		{
			var response = new Response<DataPage<ReviewDto>>();
			try
			{
				var data = await repository.ReadAll();
				List<ReviewDto> reviews = new();
				await foreach (var item in data)
				{
					reviews.Add(item.ToDto());
				}
				response.Value.Data = reviews.ToArray();
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
		public async Task<Response<DataPage<ReviewDto>>> ReadPage(int start, int count)
		{
			var response = new Response<DataPage<ReviewDto>>();
			try
			{
				var data = await repository.ReadPage(start, count);
				List<ReviewDto> reviews = new();
				await foreach (var item in data)
				{
					reviews.Add(item.ToDto());
				}
				response.Value.Data = reviews.ToArray();
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
		public async Task<Response> Update(ReviewDto review)
		{
			var response = new Response<ReviewDto>();
			try
			{
				await repository.Update(review.ToEntity());
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
			var response = new Response<ReviewDto>();
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

        public async Task<Response> CreateReview(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                await repository.CreateReview(review.ToEntity());
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
        public async Task<Response> Edit(ReviewDto review)
        {
            var response = new Response<ReviewDto>();
            try
            {
                await repository.Edit(review.ToEntity());
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
        public async Task<Response<IEnumerable<ReviewDto>>> GetByProduct(int productId)
        {
            var response = new Response<IEnumerable<ReviewDto>>();
            try
            {
                var data = repository.GetByProduct(productId);

                List<ReviewDto> tags = new();
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
    }
}
