using FashionShop.App.Interactors;
using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FashionShop.Server.Controllers.ShopPart
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductInteractor interactor;
        public ProductController(ProductInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] ProductDto product)
        {
            return await interactor.Create(product);
        }
        [HttpGet("Read")]
        public async Task<Response<ProductDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpGet("ReadAll")]
        public async Task<Response<DataPage<ProductDto>>> ReadAll()
        {
            return await interactor.ReadAll();
        }
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<ProductDto>>> GetAll()
        {
            return await interactor.GetAll();
        }
        [HttpGet("AddTag")]
        public async Task<Response> AddTag(int tagId, int productId)
        {
            return await interactor.AddTag(tagId, productId);
        }
        [HttpGet("GetByTag")]
        public async Task<Response<IEnumerable<ProductDto>>> GetByTag(int tagId)
        {
            return await interactor.GetByTag(tagId);
        }
        [HttpGet("ReadPage")]
        public async Task<Response<DataPage<ProductDto>>> ReadPage(int start, int count)
        {
            return await interactor.ReadPage(start, count);
        }
        [HttpPost("Update")]
        public async Task<Response> Update([FromBody] ProductDto product)
        {
            return await interactor.Update(product);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetSizes")]
        public async Task<Response<IEnumerable<SizeDto>>> GetSizes(int productId)
        {
            return await interactor.GetSizes(productId);
        }

        [HttpGet("AddSize")]
        public async Task<Response> AddSize(int sizeId, int productId)
        {
            return await interactor.AddSize(sizeId, productId);
        }

        [HttpGet("RemoveSize")]
        public async Task<Response> RemoveSize(int sizeId, int productId)
        {
            return await interactor.RemoveSize(sizeId, productId);
        }
        [HttpGet("RemoveTag")]
        public async Task<Response> RemoveTag(int tagId, int productId)
        {
            return await interactor.RemoveSize(tagId, productId);
        }
        [HttpGet("GetTags")]
        public async Task<Response<IEnumerable<TagDto>>> GetTags(int productId)
        {
            return await interactor.GetTags(productId);
        }
    }
}
