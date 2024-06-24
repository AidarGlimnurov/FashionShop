using FashionShop.Adapter.Transaction;
using FashionShop.App.Interactors;
using FashionShop.App.Mappers;
using FashionShop.App.Storage;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace FashionShop.Server.Controllers.ShopPart
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private ReviewInteractor interactor;
		public ReviewController(ReviewInteractor interactor)
		{
			this.interactor = interactor;
		}
		[HttpPost("Create")]
		public async Task<Response> Create([FromBody] ReviewDto review)
		{
			return await interactor.Create(review);
		}
		[HttpGet("Read")]
		public async Task<Response<ReviewDto>> Read(int id)
		{
			return await interactor.Read(id);
		}
		[HttpGet("ReadAll")]
		public async Task<Response<DataPage<ReviewDto>>> ReadAll()
		{
			return await interactor.ReadAll();
		}
		[HttpGet("ReadPage")]
		public async Task<Response<DataPage<ReviewDto>>> ReadPage(int start, int count)
		{
			return await interactor.ReadPage(start, count);
		}
		[HttpGet("Update")]
		public async Task<Response> Update([FromBody] ReviewDto review)
		{
			return await interactor.Update(review);
		}
		[HttpGet("Delete")]
		public async Task<Response> Delete(int id)
		{
			return await interactor.Delete(id);
		}


        [HttpPost("CreateReview")]
        public async Task<Response> CreateReview(ReviewDto review)
        {
            return await interactor.CreateReview(review);
        }

        [HttpPost("Edit")]
        public async Task<Response> Edit(ReviewDto review)
        {
            return await interactor.Edit(review);
        }
        [HttpGet("GetByProduct")]
        public async Task<Response<IEnumerable<ReviewDto>>> GetByProduct(int productId)
        {
            return await interactor.GetByProduct(productId);
        }
    }
}
