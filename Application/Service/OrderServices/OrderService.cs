using Application.Repository;
using Application.Service.OrderService.OrderDTOs;
using Application.Service.OrderService.OrderService;
using Application.Service.OrderServices.OrderDTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Service.OrderServices
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

        public IQueryable<OrderDto> GetOrders()
        {
            var orders = _orderRepository.GetAll();
            var result = orders.Select(x => new OrderDto
            {
                Id = x.Id,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice

            });
            return result;
        }
        public void DeleteOrder(Guid id)
        {
            var order = _orderRepository.GetById(id);
            if (order != null)
            {
                _orderRepository.Delete(order);
            }
        }
        public Order GetOrder(Guid id)
        {
            var order = _orderRepository.GetById(id);
            return order;
        }
        public List<Order> GetOrdersByUser(Guid userId)
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
            var x = _orderDetailRepository.GetAll().Where(o => o.OrderId == order.Id).ToList();
            decimal totalPrice = 0;
            foreach(var item in x)
            {
                totalPrice += (item.Price * item.Quantity);
            }
            order.TotalPrice = totalPrice;
            _orderRepository.SaveChanges();
        }
        public void UpdateOrder(Guid id, Order order)
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
