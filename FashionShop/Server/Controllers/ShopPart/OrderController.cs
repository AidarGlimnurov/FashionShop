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
	public class OrderController : ControllerBase
	{
		private OrderInteractor interactor;
		public OrderController(OrderInteractor interactor)
		{
			this.interactor = interactor;
		}
		[HttpPost("Create")]
		public async Task<Response> Create([FromBody] OrderDto order)
		{
			return await interactor.Create(order);
		}
		[HttpGet("Read")]
		public async Task<Response<OrderDto>> Read(int id)
		{
			return await interactor.Read(id);
		}
		[HttpGet("ReadAll")]
		public async Task<Response<DataPage<OrderDto>>> ReadAll()
		{
			return await interactor.ReadAll();
		}
		[HttpGet("ReadPage")]
		public async Task<Response<DataPage<OrderDto>>> ReadPage(int start, int count)
		{
			return await interactor.ReadPage(start, count);
		}
		[HttpGet("Update")]
		public async Task<Response> Update([FromBody] OrderDto order)
		{
			return await interactor.Update(order);
		}
		[HttpGet("Delete")]
		public async Task<Response> Delete(int id)
		{
			return await interactor.Delete(id);
        }

        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<OrderDto>>> GetAll()
        {
            return await interactor.GetAll();
        }
        [HttpGet("GetForUser")]
        public async Task<Response<IEnumerable<OrderDto>>> GetForUser(int userId)
        {
            return await interactor.GetForUser(userId);
        }
        [HttpGet("Get")]
        public async Task<Response<IEnumerable<OrderProductDto>>> Get(int id)
        {
            return await interactor.Get(id);
        }
        [HttpPost("CreateOrder")]
        public async Task<Response> CreateOrder([FromBody]OrderDto order)
        {
            return await interactor.CreateOrder(order, order.AllId);
        }
        [HttpPost("UpdateOrder")]
        public async Task<Response> UpdateOrder([FromBody] OrderDto order)
        {
            return await interactor.UpdateOrder(order);
        }
    }
}