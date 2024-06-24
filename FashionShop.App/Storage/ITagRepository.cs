using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
    public interface ITagRepository: IRepository<Tag>
    {
        public IAsyncEnumerable<Tag> GetAll();
    }
}
