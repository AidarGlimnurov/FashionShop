using FashionShop.App.Storage;
using FashionShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Adapter.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ShopContext context) : base(context)
        {

        }

        public async IAsyncEnumerable<Tag> GetAll()
        {

            var tags = await context.Tags.ToArrayAsync();

            foreach (var tag in tags)
            {
                yield return tag;
            }
        }
    }
}
