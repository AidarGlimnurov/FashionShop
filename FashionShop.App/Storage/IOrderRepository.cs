using FashionShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Storage
{
	public interface IOrderRepository : IRepository<Order>
	{
        public IAsyncEnumerable<Order> GetForUser(int userId);
        public IAsyncEnumerable<Order> GetAll();
        public IAsyncEnumerable<OrderProduct> Get(int id);
        public Task CreateOrder(Order order, int[] allId);
        public Task UpdateOrder(Order order);
    }
}
