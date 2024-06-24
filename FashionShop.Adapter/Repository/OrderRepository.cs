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
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(ShopContext context) : base(context)
		{

		}

        public async Task CreateOrder(Order order, int[] allId)
        {
            order.User = await context.Users.FirstOrDefaultAsync(u => u.Id == order.UserId);
            context.Add(order);
            await context.SaveChangesAsync();

            var ord = await context.Orders.Where(o => o.UserId == order.UserId)
                                           .OrderByDescending(o => o.Id)
                                           .FirstOrDefaultAsync();

            if (ord != null)
            {
                foreach (var id in allId)
                {
                    var size = await context.Sizes.Include(s => s.Product)
                                                  .FirstOrDefaultAsync(s => s.Id == id);

                    if (size != null)
                    {
                        var orderProduct = new OrderProduct()
                        {
                            ProductId = id,
                            Product = size,
                            Order = ord,
                            OrderId = ord.Id
                        };
                        size.Quantity--;
                        context.Update(size);
                        try
                        {
                            var basket = await context.BasketProducts.Include(b => b.Basket).Include(b => b.SizeProduct)
                                .FirstOrDefaultAsync(b => b.Basket.UserId == order.UserId && b.SizeProduct.Id == size.Id);
                            context.Remove(basket);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        context.Add(orderProduct);
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public async IAsyncEnumerable<Order> GetAll()
        {
            var order = context.Orders.Include(o => o.User);
            foreach (var o in order)
            {
                yield return o;
            }
        }

        public async IAsyncEnumerable<Order> GetForUser(int userId)
        {
            var orderPr = context.Orders.Include(o => o.User)
                .Where(o => o.UserId == userId);
            foreach (var order in orderPr)
            {
                yield return order;
            }
        }

        public async IAsyncEnumerable<OrderProduct> Get(int id)
        {
            var orderPr = context.OrderProducts.Include(o => o.Product).ThenInclude(s=>s.Product).Include(o => o.Order)
                .Where(o => o.Order.Id == id);
            foreach (var order in orderPr)
            {
                yield return order;
            }
        }

        public async Task UpdateOrder(Order order)
        {
            var or = await context.Orders.Include(o => o.User).FirstOrDefaultAsync(o => o.Id == order.Id);
            or.User = await context.Users.FirstOrDefaultAsync(u => u.Id == order.UserId);
            or.Status = order.Status;
            context.Update(or);
        }
    }
}
