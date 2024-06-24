using FashionShop.App.Interactors;
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
	public class SizeController : ControllerBase
	{
		private SizeInteractor interactor;
		public SizeController(SizeInteractor interactor)
		{
			this.interactor = interactor;
		}
		[HttpPost("Create")]
		public async Task<Response> Create([FromBody] SizeDto size)
		{
			return await interactor.Create(size);
		}
        [HttpPost("CreateWithEntity")]
        public async Task<Response> CreateWithEntity([FromBody] SizeDto size)
        {
            return await interactor.CreateWithEntity(size);
        }
        [HttpGet("GetSize")]
        public async Task<Response<SizeDto>> GetSize(int sizeId)
        {
            return await interactor.GetSize(sizeId);
        }
        [HttpGet("Read")]
		public async Task<Response<SizeDto>> Read(int id)
		{
			return await interactor.Read(id);
		}
		[HttpGet("ReadAll")]
		public async Task<Response<DataPage<SizeDto>>> ReadAll()
		{
			return await interactor.ReadAll();
		}
		[HttpGet("ReadPage")]
		public async Task<Response<DataPage<SizeDto>>> ReadPage(int start, int count)
		{
			return await interactor.ReadPage(start, count);
		}
		[HttpGet("Update")]
		public async Task<Response> Update([FromBody] SizeDto size)
		{
			return await interactor.Update(size);
		}
        [HttpGet("UpdateWithEntity")]
        public async Task<Response> UpdateWithEntity([FromBody] SizeDto size)
        {
            return await interactor.Update(size);
        }
        [HttpGet("Delete")]
		public async Task<Response> Delete(int id)
		{
			return await interactor.Delete(id);
		}
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<SizeDto>>> GetAll()
        {
            return await interactor.GetAll();
        }
        [HttpGet("GetForProduct")]
        public async Task<Response<IEnumerable<SizeDto>>> GetForProduct(int id)
        {
			return await interactor.GetForProduct(id);
        }
    }
}
