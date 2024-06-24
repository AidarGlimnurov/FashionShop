using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IRepository<T>
		where T :  class
	{
		public Task Create(T entity);
		public Task<T> Read(int id);
		public Task<IAsyncEnumerable<T>> ReadAll();
		public Task<IAsyncEnumerable<T>> ReadPage(int start, int count);
		public Task Update(T entity);
		public Task Delete(int id);
	}
}
