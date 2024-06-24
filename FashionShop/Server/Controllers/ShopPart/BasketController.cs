using FashionShop.Adapter.Transaction;
using FashionShop.App.Interactors;
using FashionShop.App.Storage;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FashionShop.Domain.Entity;
using System.Collections;
using FashionShop.Client.Pages;

namespace FashionShop.Server.Controllers.ShopPart
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private BasketInteractor interactor;
        public BasketController(BasketInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] BasketDto basket)
        {
            return await interactor.Create(basket);
        }
        [HttpGet("GetGetForUser")]
        public async Task<Response<IEnumerable<SizeDto>>> GetForUser(int userId)
        {
            return await interactor.GetForUser(userId);
        }

        [HttpGet("Read")]
        public async Task<Response<BasketDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpGet("ReadAll")]
        public async Task<Response<DataPage<BasketDto>>> ReadAll()
        {
            return await interactor.ReadAll();
        }
        [HttpGet("ReadPage")]
        public async Task<Response<DataPage<BasketDto>>> ReadPage(int start, int count)
        {
            return await interactor.ReadPage(start, count);
        }
        [HttpGet("Update")]
        public async Task<Response> Update([FromBody] BasketDto basket)
        {
            return await interactor.Update(basket);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetProduct")]
        public async Task<Response<SizeDto>> GetProduct(int userId, int productId)
        {
            return await interactor.GetProduct(userId, productId);
        }

        [HttpGet("AddInBasket")]
        public async Task<Response> AddInBasket(int userId, int productId)
        {
            return await interactor.AddInBasket(userId, productId);
        }

        [HttpGet("CreateBasketForUser")]
        public async Task<Response> CreateBasketForUser(int userId)
        {
            return await interactor.CreateBasketForUser(userId);
        }
        [HttpGet("RemoveInBasket")]
        public async Task<Response> RemoveInBasket(int userId, int productId)
        {
            return await interactor.RemoveInBasket(userId, productId);
        }
    }
}
