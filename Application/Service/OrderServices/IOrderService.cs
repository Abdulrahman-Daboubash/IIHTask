using Application.Service.OrderService.OrderDTOs;
using Application.Service.OrderServices.OrderDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderService.OrderService
{
    public interface IOrderService
    {
        public void CreateOrder(CreateOrderDto dto);
        public IQueryable<OrderDto> GetOrders();
        public Order GetOrder(Guid id);
        public List<Order> GetOrdersByUser(Guid userId);
        public void DeleteOrder(Guid id);
        public void UpdateOrder(Guid id, Order order);
    }
}
