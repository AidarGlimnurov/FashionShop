using FashionShop.Domain.Entity;
using FashionShop.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(this Order order)
        {
            var orderDto = new OrderDto
            {
                Id = order.Id,
                Index = order.Index,
                Adress = order.Adress,
                Fio = order.Fio,
                Status = order.Status,
                User = order.User?.ToDto(),
                UserId = order?.UserId,
            };

            return orderDto;
        }

        public static Order ToEntity(this OrderDto orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                Index = orderDto.Index,
                Adress = orderDto.Adress,
                Fio = orderDto.Fio,
                Status = orderDto.Status,
                User = orderDto.User?.ToEntity(),
                UserId = orderDto?.UserId,
            };

            return order;
        }
    }
}
