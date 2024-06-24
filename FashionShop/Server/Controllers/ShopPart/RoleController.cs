using FashionShop.App.Interactors;
using FashionShop.Shared.Dtos;
using FashionShop.Shared.OutputData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FashionShop.Server.Controllers.ShopPart
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private RoleInteractor interactor;
		public RoleController(RoleInteractor interactor)
		{
			this.interactor = interactor;
		}
		[HttpPost("Create")]
		public async Task<Response> Create([FromBody] RoleDto role)
		{
			return await interactor.Create(role);
		}
		[HttpGet("Read")]
		public async Task<Response<RoleDto>> Read(int id)
		{
			return await interactor.Read(id);
		}
		[HttpGet("ReadAll")]
		public async Task<Response<DataPage<RoleDto>>> ReadAll()
		{
			return await interactor.ReadAll();
		}
		[HttpGet("ReadPage")]
		public async Task<Response<DataPage<RoleDto>>> ReadPage(int start, int count)
		{
			return await interactor.ReadPage(start, count);
		}
		[HttpGet("Update")]
		public async Task<Response> Update([FromBody] RoleDto role)
		{
			return await interactor.Update(role);
		}
		[HttpGet("Delete")]
		public async Task<Response> Delete(int id)
		{
			return await interactor.Delete(id);
		}
	}
}
