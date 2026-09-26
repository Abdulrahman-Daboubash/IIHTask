using Application.Repository;
using Application.Service.OrderDetailService.OrderDetailService;
using Application.Service.OrderDetailServices.OrderDetailDTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Application.Service.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IGenericRepository<OrderDetail> _orderDetailRepository;
        public OrderDetailService(IGenericRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public void DeleteOrderDetail(Guid id)
        {
            var detail = _orderDetailRepository.GetById(id);
            if (detail != null)
            {
                _orderDetailRepository.Delete(detail);
            }
        }

        public OrderDetail GetOrderDetail(Guid id)
        {
            var detail = _orderDetailRepository.GetById(id);
            return detail;
        }

        public IQueryable<OrderDetailDto> GetOrderDetails()
        {
            var details = _orderDetailRepository.GetAll();
            var result = details.Select(x => new OrderDetailDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price

            });
            return result;
        }

        public List<OrderDetail> GetDetailsByOrderId(Guid orderId)
        {
            var details = _orderDetailRepository.GetAll()
                .Where(od => od.OrderId == orderId)
                .ToList();

            return details;
        }
        public void UpdateOrderDetail(Guid id, OrderDetail orderDetail)
        {
            var x = _orderDetailRepository.GetById(id);
            if (x != null)
            {
                
                    x.OrderId = orderDetail.OrderId;
                    x.ProductId = orderDetail.ProductId;
                    x.Quantity = orderDetail.Quantity;
                    x.Price = orderDetail.Price;

                    _orderDetailRepository.Update(x);
                
            }
        }
    }
}
