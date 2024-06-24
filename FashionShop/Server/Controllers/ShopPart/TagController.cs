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
    public class TagController : ControllerBase
    {
        private TagInteractor interactor;
        public TagController(TagInteractor interactor)
        {
            this.interactor = interactor;
        }
        [HttpPost("Create")]
        public async Task<Response> Create([FromBody] TagDto tag)
        {
            return await interactor.Create(tag);
        }
        [HttpGet("Read")]
        public async Task<Response<TagDto>> Read(int id)
        {
            return await interactor.Read(id);
        }
        [HttpGet("ReadAll")]
        public async Task<Response<DataPage<TagDto>>> ReadAll()
        {
            return await interactor.ReadAll();
        }
        [HttpGet("ReadPage")]
        public async Task<Response<DataPage<TagDto>>> ReadPage(int start, int count)
        {
            return await interactor.ReadPage(start, count);
        }
        [HttpGet("Update")]
        public async Task<Response> Update([FromBody] TagDto tag)
        {
            return await interactor.Update(tag);
        }
        [HttpGet("Delete")]
        public async Task<Response> Delete(int id)
        {
            return await interactor.Delete(id);
        }
        [HttpGet("GetAll")]
        public async Task<Response<IEnumerable<TagDto>>> GetAll()
        {
            return await interactor.GetAll();
        }
    }
}
