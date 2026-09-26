using Application.Repository;
using Application.Service.OrderService.OrderDTOs;
using Application.Service.OrderService.OrderService;
using Application.Service.OrderServices.OrderDTOs;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.Service.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly string? _connectionString;

        public OrderService(IGenericRepository<Order> orderRepository , IGenericRepository<OrderDetail> orderDetailRepository, IGenericRepository<Product> productRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _connectionString = configuration.GetConnectionString("Default");
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
            var table = new DataTable();
            table.Columns.Add("ProductId", typeof(Guid));
            table.Columns.Add("Quantity", typeof(int));

            foreach (var item in dto.Items)
            {
                table.Rows.Add(item.ProductId, item.Quantity);
            }

           
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", dto.UserId);
                parameters.Add("@Items", table.AsTableValuedParameter("dbo.OrderDetailType"));

                
                connection.Execute("sp_CreateOrder", parameters, commandType: CommandType.StoredProcedure);
            }
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
