using Application.Service.OrderDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public interface IOrderService
    {
        public void CreateOrder(CreateOrderDto dto);
        public List<Order> GetOrders();
        public Order GetOrder(int id);
        public List<Order> GetOrdersByUser(int userId);
        public void DeleteOrder(int id);
        public void UpdateOrder(int id, Order order);
    }
}
