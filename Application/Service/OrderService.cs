using Application.Repository;
using Application.Service.OrderDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<Product> _productRepository;
        public OrderService(IGenericRepository<Order> orderRepository , IGenericRepository<OrderDetail> orderDetailRepository, IGenericRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public List<Order> GetOrders()
        {
            var orders = _orderRepository.GetAll();
            return orders;
        }
        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            if (order != null)
            {
                _orderRepository.Delete(order);
            }
        }
        public Order GetOrder(int id)
        {
            var order = _orderRepository.GetById(id);
            return order;
        }
        public List<Order> GetOrdersByUser(int userId)
        {
           
            var orders = _orderRepository.GetAll()
                .Where(o => o.UserId == userId).ToList();

            return orders;
        }

        public void CreateOrder(CreateOrderDto dto)
        {
            var order = new Order()
            {
                UserId = dto.UserId
            };
            _orderRepository.Insert(order);
            foreach(var item in dto.Items)
            {
                var product =_productRepository.GetById(item.ProductId);
                decimal price = product.Price;
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = price
                };
                _orderDetailRepository.Insert(orderDetail);
            }
        }
        public void UpdateOrder(int id, Order order)
        {
            var x = _orderRepository.GetById(id);
            if (x != null)
            {
                x.UserId = order.UserId;
                x.TotalPrice = order.TotalPrice;
                _orderRepository.Update(x);
            }
        }
    }
}
